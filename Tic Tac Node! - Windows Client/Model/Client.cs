using System;
using Quobject.SocketIoClientDotNet.Client;
using Tic_Tac_Node__Windows_Client.JsonModel;
using static Tic_Tac_Node__Windows_Client.Properties.Enumeration;
using Tic_Tac_Node__Windows_Client.UiComponent.Chat.ChatComponent;

namespace Tic_Tac_Node__Windows_Client.Model
{
    class Client
    {
        static private Socket Socket { get; set; } = null;
        static public string SocketId { get; set; } = "";
        static public string RoomId { get; set; } = "";
        static public string Username { get; set; } = "";
        static public bool RecievedInvitation { get; set; } = false;
        static public bool IsInGame { get; set; } = false;
        static public bool IsOnTurn { get; set; } = false;
        static public string OpponentsName { get; set; } = null;
        static public string OpponentsId { get; set; } = null;
        

        public Client()
        {
        }

        public Client(Socket sock)
        {
            Socket = sock;
            Util.Listeners listeners = new Util.Listeners(Socket, this);
        }

        static public Socket GetSocket()
        {
            return Socket;
        }

        static public void StartMatchmaking()
        {
            Socket.Emit("matchmaking");
        }

        static public void Quit()
        {
            Socket.Emit("quit", "quit");
        }

        static public void EmitEndSession()
        {
            Socket.Emit("endSession");
        }

        static public void EmitRevancheRequest()
        {
            Socket.Emit("revancheRequest", OpponentsId);
            MessageList.Clear();
            MessageList.Add(new Message("", MessageDisplayType.RevancheInvitationSent));
        }

        static public void EmitPlayAgainRequest()
        {
            Socket.Emit("playAgainRequest", OpponentsId);
            MessageList.Clear();
            MessageList.Add(new Message("", MessageDisplayType.PlayAgainInvitationSent));
        }

        static public void Turn(int ButtonValue)
        {
            Socket.Emit("turn", ButtonValue);
        }

        static public void SendMessage(string message)
        {
            Socket.Emit("message", message, RoomId, Username);
        }

        static public void EmitUsername(string input) {
            Username = input;
            Socket.Emit("userChoseName", input);
        }

        static public void AcceptRevanche()
        {
            Socket.Emit("revancheAccept");
            MessageList.Clear();
            MessageList.Add(new Message(Client.OpponentsName + " accepted a revanche", MessageDisplayType.MessageInfo));
        }

        static public void AcceptPlayAgain()
        {
            Socket.Emit("playAgainAccept");
            MessageList.Clear();
            MessageList.Add(new Message(Client.OpponentsName + " accepted a rematch", MessageDisplayType.MessageInfo));
        }

        static public void DeclineInvitation()
        {
            Socket.Emit("quit", "declined");
        }

        static public void CancelInvitation()
        {
            Socket.Emit("quit", "canceled");
        }
    }
}
