using System;
using Quobject.SocketIoClientDotNet.Client;
using Tic_Tac_Node__Windows_Client.JsonModel;
using Tic_Tac_Node__Windows_Client.Model;
using Tic_Tac_Node__Windows_Client.Model.JsonModel;
using Tic_Tac_Node__Windows_Client.View;
using Tic_Tac_Node__Windows_Client.ViewModel;
using static Tic_Tac_Node__Windows_Client.Properties.Enumeration;

namespace Tic_Tac_Node__Windows_Client.Util
{
    class Listeners
    {
        static public event EventHandler MatchStart;
        static public event EventHandler MatchAbort;
        static public event EventHandler TurnBroadcast;
        static public event EventHandler IsOnTurn;
        static public event EventHandler IsWaiting;
        static public event EventHandler OnlineUsers;
        static public event EventHandler ScoreBroadcast;
        static public event EventHandler ChatroomSwitched;
        static public event EventHandler MatchResult;




        public Listeners(Socket socket, Client client) {

            socket.On("message", (Action<object>)((data) =>
            {
                Console.WriteLine("MESSAGE INCOMING");
                Message message = new Message(data.ToString());
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
               {
                   MessageList.Add(message);
               });

                Console.WriteLine((string)("+++++++++++ MESSAGE:" + message.Text + " " + message.Type + " +++++++++++"));
            }));

            socket.On("roomSwitched", (data) =>
            {
                RoomParameter roomParameter = new RoomParameter(data.ToString());
                Client.RoomId = roomParameter.RoomId;
                Console.WriteLine("+++++++++++ ROOM SWITCHED:" + roomParameter.RoomName + " +++++++++++");
                OnChatroomSwitched(roomParameter.RoomName);
            });

            socket.On("isWaiting", () =>
             {
                 OnIsWaiting();
                 System.Windows.Application.Current.Dispatcher.Invoke(delegate
                 {
                     MessageList.Clear();
                     MessageList.Add(new Message("Waiting for an Opponent...", MessageDisplayType.MessageInfo));
                 });
             });

            socket.On("gameover", () =>
            {
                Console.WriteLine("GAMEOVER");
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    Client.IsOnTurn = false;
                    Client.EmitEndSession();
                    MessageList.Clear();
                    OnMatchAbort();
                });
            });

            socket.On("turnBroadcast", (data) =>
            {
                OnTurnBroadcast(new TurnBroadcast(data.ToString()));
            });

            socket.On("gameBegins", () =>
            {
            });

            socket.On("cSharpSaveReset", () =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    OnMatchStart(true);
                });
            });

            socket.On("matchParameter", (data) =>
            {
                MatchParameter mP = new MatchParameter(data.ToString());
                Client.OpponentsName = mP.OpponentsName;
                Client.OpponentsId = mP.OpponentsId;
                Client.IsOnTurn = mP.FirstTurn;
                var delayedTurnEmit = System.Threading.Tasks.Task.Run(() => OnSetOnTurn(mP.FirstTurn));
                delayedTurnEmit.Wait(TimeSpan.FromMilliseconds(300));
                OnSetOnTurn(mP.FirstTurn);
            });

            socket.On("winnerBroadcast", (data) => 
            {
                WinnerBroadcast wB = new WinnerBroadcast(data.ToString());
                OnMatchResult(wB.animation);
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    if(wB.isWinner)
                        MessageList.Add(new Message("You Won!", MessageDisplayType.ResultWin));
                    else
                        MessageList.Add(new Message("You Lost!", MessageDisplayType.ResultLose));
                });
            });

            socket.On("drawBroadcast", (data) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    MessageList.Add(new Message("You both are too dumb to win", MessageDisplayType.ResultDraw));
                });
            });

            socket.On("scoreBroadcast", (data) => 
            {
                ScoreBroadcast sb = new ScoreBroadcast(data.ToString());
                OnScoreBroadcast("You   " + sb.clientScore + " : " + sb.opponentsScore + "   " + Client.OpponentsName);
                
            });

            socket.On("revancheRequest", (data) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    //TODO
                    MessageList.Add(new Message(Client.OpponentsName + " wants a revanche... Take it or leave it.", MessageDisplayType.RevancheInvitation));
                });
            });

            socket.On("playAgainRequest", (data) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    //TODO
                    MessageList.Add(new Message(Client.OpponentsName + " wants to play again...", MessageDisplayType.PlayAgainInvitation));
                });
            });

            socket.On("revancheAccepted", (data) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    MessageList.Clear();
                    OnMatchStart(true);
                    MessageList.Add(new Message(Client.OpponentsName + " wants to kick your ass again!", MessageDisplayType.MessageInfo));
                });
            });

            socket.On("playAgainAccepted", (data) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    MessageList.Clear();
                    OnMatchStart(true);
                    MessageList.Add(new Message(Client.OpponentsName + " wants to play again!", MessageDisplayType.MessagePrimary));
                });
            });

            socket.On("firstTurn", () =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    MessageList.Clear();
                });
            });

            socket.On("setOnTurn", (data) =>
            {
                var delayedTurnEmit = System.Threading.Tasks.Task.Run(() => OnSetOnTurn((bool)data));
                delayedTurnEmit.Wait(TimeSpan.FromMilliseconds(400));
                OnSetOnTurn((bool)data);
                Client.IsOnTurn = (bool)data;
            });

            socket.On("opponentFound", (data) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(delegate
                {
                    OnMatchStart(false);
                    MessageList.Clear();
                    MessageList.Add(new Message("Opponent found, you're playing against " + data , MessageDisplayType.MessageInfo));
                    System.Windows.Application.Current.MainWindow.DataContext = new GameViewModel();
                });
            });

            socket.On("idCommit", (data) =>
            {
                Client.SocketId = data.ToString();
                Console.WriteLine("+++++++++++ ID COMMIT:" + data+ " +++++++++++");
            });

            socket.On("updateOnlineUsers", (data) =>
            {
                OnUpdateOnlineUsers((int)(long) data);
            });
        }

        private void OnMatchStart(bool IsRematch)
        {
            MatchStart?.Invoke(IsRematch, EventArgs.Empty);
        }

        private void OnMatchAbort()
        {
            MatchAbort?.Invoke(this, EventArgs.Empty);
        }

        private void OnIsWaiting()
        {
            IsWaiting?.Invoke(this, EventArgs.Empty);
        }

        private void OnTurnBroadcast(TurnBroadcast data)
        {
            if(data != null)
            {
                TurnBroadcast?.Invoke(data, EventArgs.Empty);
            }
        }

        private void OnSetOnTurn(bool onTurn)
        {
            if(onTurn)
                IsOnTurn?.Invoke("Your turn", EventArgs.Empty);
            else
                IsOnTurn?.Invoke(Client.OpponentsName + "s turn", EventArgs.Empty);
        }

        private void OnUpdateOnlineUsers(int onlineUsers)
        {
            OnlineUsers?.Invoke("Players Online: " + onlineUsers, EventArgs.Empty);
        }

        private void OnScoreBroadcast(string score)
        {
            ScoreBroadcast?.Invoke(score, EventArgs.Empty);
        }

        private void OnChatroomSwitched(string chatroom)
        {
            ChatroomSwitched?.Invoke("Chatroom: " + chatroom, EventArgs.Empty);
        }

        private void OnMatchResult(string result)
        {
            MatchResult?.Invoke(result, EventArgs.Empty);
        }
    }
}