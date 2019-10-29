using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Media;
using Tic_Tac_Node__Windows_Client.Model;
using static Tic_Tac_Node__Windows_Client.Properties.Enumeration;

namespace Tic_Tac_Node__Windows_Client.JsonModel
{
    public class Message
    {
        public Message(string Text, MessageDisplayType MessageType)
        {
            this.Text = Text;
            this.MessageType = MessageType;
            var bc = new BrushConverter();
            switch (MessageType)
            {
                case MessageDisplayType.ResultWin:
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Visible;
                    IsMessage = Visibility.Hidden;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#d4edda");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#28a745");
                    PlayAgainButtonVisible = Visibility.Collapsed;
                    RevancheButtonVisible = Visibility.Collapsed;
                    break;
                case MessageDisplayType.ResultLose:
                    ResultButton = RevancheResult;
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Visible;
                    IsMessage = Visibility.Hidden;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#f8d7da");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#dc3545");
                    PlayAgainButtonVisible = Visibility.Collapsed;
                    RevancheButtonVisible = Visibility.Visible;
                    break;
                case MessageDisplayType.ResultDraw:
                    ResultButton = PlayAgainResult;
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Visible;
                    IsMessage = Visibility.Hidden;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#fff3cd");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#ffc107");
                    PlayAgainButtonVisible = Visibility.Visible;
                    RevancheButtonVisible = Visibility.Collapsed;
                    break;
                case MessageDisplayType.PlayAgainInvitation:
                    Title = PlayAgainInvitationTitle;
                    SecondTitle = PlayAgainSecondTitle;
                    AcceptString = PlayAgainAcc;
                    DeclineString = PlayAgainDec;
                    IsInvitation = Visibility.Visible;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Hidden;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#555");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#333");
                    break;
                case MessageDisplayType.RevancheInvitation:
                    Title = RevancheInvitationTitle;
                    SecondTitle = RevancheSecondTitle;
                    AcceptString = RevancheAcc;
                    DeclineString = RevancheDec;
                    IsInvitation = Visibility.Visible;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Hidden;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#17a2b8");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#333");
                    break;
                case MessageDisplayType.PlayAgainInvitationSent:
                    Title = PlayAgainInvitationTitle;
                    SecondTitle = "Waiting for " + Client.OpponentsName + "s okay...";
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Hidden;
                    IsInvitationSent = Visibility.Visible;
                    Background = (SolidColorBrush)bc.ConvertFrom("#555");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#333");
                    break;
                case MessageDisplayType.RevancheInvitationSent:
                    Title = RevancheWaitingTitle;
                    SecondTitle = "Waiting for " + Client.OpponentsName + "s okay...";
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Hidden;
                    IsInvitationSent = Visibility.Visible;
                    Background = (SolidColorBrush)bc.ConvertFrom("#17a2b8");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#333");
                    break;
                case MessageDisplayType.Message:
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Visible;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#dddddd");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#cfcfcf");
                    break;
                case MessageDisplayType.MessageDanger:
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Visible;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#f8d7da");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#dc3545");
                    break;
                case MessageDisplayType.MessageInfo:
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Visible;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#d1ecf1");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#bee5eb");
                    break;
                case MessageDisplayType.MessagePrimary:
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Visible;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#d6d6d6");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#c6c6c6");
                    break;
                case MessageDisplayType.MessageWarning:
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Visible;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#fff3cd");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#ffc107");
                    break;
                default:
                    IsInvitation = Visibility.Collapsed;
                    IsResult = Visibility.Hidden;
                    IsMessage = Visibility.Visible;
                    IsInvitationSent = Visibility.Collapsed;
                    Background = (SolidColorBrush)bc.ConvertFrom("#dddddd");
                    Borderbrush = (SolidColorBrush)bc.ConvertFrom("#cfcfcf");
                    break;
            }
        }

        [JsonConstructor]
        public Message(string data)
        {
            Message message;
            if (data != null)
            {
                message = JsonConvert.DeserializeObject<Message>(data);
                Text = message.Text;
                var bc = new BrushConverter();
                switch (message.Type)
                {
                    case "primary":
                        System.Windows.Application.Current.Dispatcher.Invoke(delegate
                        {
                            MessageType = MessageDisplayType.MessagePrimary;
                            IsInvitation = Visibility.Collapsed;
                            IsResult = Visibility.Hidden;
                            IsMessage = Visibility.Visible;
                            IsInvitationSent = Visibility.Collapsed;
                            Background = (SolidColorBrush)bc.ConvertFrom("#d6d6d6");
                            Borderbrush = (SolidColorBrush)bc.ConvertFrom("#c6c6c6");
                        });
                        
                        break;
                    case "secondary":
                        System.Windows.Application.Current.Dispatcher.Invoke(delegate
                        {
                            MessageType = MessageDisplayType.Message;
                            IsInvitation = Visibility.Collapsed;
                            IsResult = Visibility.Hidden;
                            IsMessage = Visibility.Visible;
                            IsInvitationSent = Visibility.Collapsed;
                            Background = (SolidColorBrush)bc.ConvertFrom("#dddddd");
                            Borderbrush = (SolidColorBrush)bc.ConvertFrom("#cfcfcf");
                        });
                       
                        break;
                    case "warning":
                        System.Windows.Application.Current.Dispatcher.Invoke(delegate
                        {
                            MessageType = MessageDisplayType.MessageWarning;
                            IsInvitation = Visibility.Collapsed;
                            IsResult = Visibility.Hidden;
                            IsMessage = Visibility.Visible;
                            IsInvitationSent = Visibility.Collapsed;
                            Background = (SolidColorBrush)bc.ConvertFrom("#fff3cd");
                            Borderbrush = (SolidColorBrush)bc.ConvertFrom("#ffc107");
                        });
                        
                        break;
                    case "info":
                        System.Windows.Application.Current.Dispatcher.Invoke(delegate
                        {
                            MessageType = MessageDisplayType.MessageInfo;
                            IsInvitation = Visibility.Collapsed;
                            IsResult = Visibility.Hidden;
                            IsMessage = Visibility.Visible;
                            IsInvitationSent = Visibility.Collapsed;
                            Background = (SolidColorBrush)bc.ConvertFrom("#d1ecf1");
                            Borderbrush = (SolidColorBrush)bc.ConvertFrom("#bee5eb");
                        });
                       
                        break;
                    case "danger":
                        System.Windows.Application.Current.Dispatcher.Invoke(delegate
                        {
                            MessageType = MessageDisplayType.MessageDanger;
                            IsInvitation = Visibility.Collapsed;
                            IsResult = Visibility.Hidden;
                            IsMessage = Visibility.Visible;
                            IsInvitationSent = Visibility.Collapsed;
                            Background = (SolidColorBrush)bc.ConvertFrom("#f8d7da");
                            Borderbrush = (SolidColorBrush)bc.ConvertFrom("#dc3545");
                        });
                        
                        break;
                    default:
                        System.Windows.Application.Current.Dispatcher.Invoke(delegate
                        {
                            MessageType = MessageDisplayType.Message;
                            IsInvitation = Visibility.Collapsed;
                            IsResult = Visibility.Hidden;
                            IsMessage = Visibility.Visible;
                            IsInvitationSent = Visibility.Collapsed;
                            Background = (SolidColorBrush)bc.ConvertFrom("#dddddd");
                            Borderbrush = (SolidColorBrush)bc.ConvertFrom("#cfcfcf");
                        });
                        
                        break;
                }
                IsInvitation = Visibility.Collapsed;
                IsResult = Visibility.Hidden;
                IsMessage = Visibility.Visible;
                IsInvitationSent = Visibility.Collapsed;
            }
        }

        public string Text { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string SecondTitle { get; set; }
        public string AcceptString { get; set; }
        public string DeclineString { get; set; }
        public string WaitingTitle { get; set; }
        public string ResultButton { get; set; }
        public SolidColorBrush Background { get; set; }
        public SolidColorBrush Borderbrush { get; set; }
        public MessageDisplayType MessageType { get; set; }
        public Visibility IsInvitation { get; set; }
        public Visibility IsMessage { get; set; }
        public Visibility IsResult { get; set; }
        public Visibility PlayAgainButtonVisible { get; set; }
        public Visibility RevancheButtonVisible { get; set; }
        public Visibility IsInvitationSent { get; set; }

        public const string RevancheInvitationTitle = "Revanche Invitation";
        public const string PlayAgainInvitationTitle = "Rematch Invitation";
        public const string PlayAgainSecondTitle = "Play Again?";
        public const string RevancheSecondTitle = "Revanche?";
        public const string PlayAgainAcc = "#metoo";
        public const string RevancheAcc = "I take it!";
        public const string PlayAgainDec = "Noooo!";
        public const string RevancheDec = "No thanks!";
        public const string PlayAgainWaitingTitle = "Rematch invitation send";
        public const string RevancheWaitingTitle = "Revanche invitation send";
        public const string RevancheResult = "Revanche";
        public const string PlayAgainResult = "Play again";
    }
}