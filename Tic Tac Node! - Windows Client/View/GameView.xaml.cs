using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tic_Tac_Node__Windows_Client.Model;
using Tic_Tac_Node__Windows_Client.Model.JsonModel;
using Tic_Tac_Node__Windows_Client.Util;

namespace Tic_Tac_Node__Windows_Client.View
{
    /// <summary>
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {

        public GameView()
        {
            InitializeComponent();
            Listeners.TurnBroadcast += new EventHandler(WriteOnGameboard);
            Listeners.MatchResult += new EventHandler(PrintResult);
            Listeners.MatchStart += new EventHandler(ResetGameBoard);
        }

        private void ResetGameBoard (object sender, EventArgs e)
        {
            var bc = new BrushConverter();

            Button0.Content = "";
            Button0.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button1.Content = "";
            Button1.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button2.Content = "";
            Button2.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button3.Content = "";
            Button3.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button4.Content = "";
            Button4.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button5.Content = "";
            Button5.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button6.Content = "";
            Button6.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button7.Content = "";
            Button7.Background = (Brush)bc.ConvertFrom("#17a2b8");

            Button8.Content = "";
            Button8.Background = (Brush)bc.ConvertFrom("#17a2b8");
        }

        private void WriteOnGameboard(object sender, EventArgs e)
        {
            TurnBroadcast tB = (TurnBroadcast) sender;

            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                switch (tB.ButtonValue)
                {
                    case 0:
                        Button0.Content = tB.Char;
                        break;
                    case 1:
                        Button1.Content = tB.Char;
                        break;
                    case 2:
                        Button2.Content = tB.Char;
                        break;
                    case 3:
                        Button3.Content = tB.Char;
                        break;
                    case 4:
                        Button4.Content = tB.Char;
                        break;
                    case 5:
                        Button5.Content = tB.Char;
                        break;
                    case 6:
                        Button6.Content = tB.Char;
                        break;
                    case 7:
                        Button7.Content = tB.Char;
                        break;
                    case 8:
                        Button8.Content = tB.Char;
                        break;

                    default:
                        break;
                }
            });
        }

        private void PrintResult (object sender, EventArgs e)
        {
            var bc = new BrushConverter();
            switch ((string) sender)
            {
                case "diagonal0":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button0.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button4.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button8.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
                case "diagonal1":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button2.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button4.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button6.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
                case "vertical0":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button0.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button3.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button6.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
                case "vertical1":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button1.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button4.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button7.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
                case "vertical2":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button2.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button5.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button8.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
                case "horizontal0":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button0.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button1.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button2.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
                case "horizontal1":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button3.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button4.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button5.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
                case "horizontal2":
                    System.Windows.Application.Current.Dispatcher.Invoke(delegate
                    {
                        Button6.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button7.Background = (Brush)bc.ConvertFrom("#ff4081");
                        Button8.Background = (Brush)bc.ConvertFrom("#ff4081");
                    });
                    break;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChatSubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if(Button0.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(0);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (Button1.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Button2.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(2);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (Button3.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(3);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (Button4.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(4);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (Button5.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(5);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (Button6.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(6);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (Button7.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(7);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (Button8.Content.ToString() == "" && Client.IsOnTurn) Client.Turn(8);
        }

        private void ChatWrapperControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
