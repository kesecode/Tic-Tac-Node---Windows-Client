using System;
using System.Windows;
using System.Windows.Controls;
using Tic_Tac_Node__Windows_Client.Model;
using Tic_Tac_Node__Windows_Client.UiComponent.Buttons;

namespace Tic_Tac_Node__Windows_Client.View
{
    /// <summary>
    /// Interaktionslogik für LobbyView.xaml
    /// </summary>
    public partial class LobbyView : UserControl
    {
        static public event EventHandler LobbyViewInitialized;

        public LobbyView()
        {
            InitializeComponent();
            OnLobbyViewInitialized();
        }

        private void OnLobbyViewInitialized()
        {
            LobbyViewInitialized?.Invoke(this, EventArgs.Empty);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        /*
         * Toggle depending on server events (saver)
         * 
         * public void toggleButtons()
        {
            if (MatchmakingButton.Visibility == Visibility.Hidden)
            {
                MatchmakingButton.Visibility = Visibility.Visible;
                QuitButton.Visibility = Visibility.Hidden;
            } else
            {
                MatchmakingButton.Visibility = Visibility.Hidden;
                QuitButton.Visibility = Visibility.Visible;
            }
        }*/
    }
}
