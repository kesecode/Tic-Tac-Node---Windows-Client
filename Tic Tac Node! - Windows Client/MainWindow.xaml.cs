using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tic_Tac_Node__Windows_Client.Model;
using Tic_Tac_Node__Windows_Client.UiComponent.Batches;
using Tic_Tac_Node__Windows_Client.UiComponent.Buttons;
using Tic_Tac_Node__Windows_Client.Util;
using Tic_Tac_Node__Windows_Client.View;
using Tic_Tac_Node__Windows_Client.ViewModel;

namespace Tic_Tac_Node__Windows_Client
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ConnectViewModel();
            Listeners.MatchStart += new EventHandler(ActivateMatchState);
            Listeners.MatchAbort += new EventHandler(ActivateLobbyState);
            Listeners.IsWaiting += new EventHandler(ActivateIsWaitingState);
            Listeners.IsOnTurn += new EventHandler(SetTurnBatch);
            Listeners.OnlineUsers += new EventHandler(SetOnlineBatch);
            Listeners.ChatroomSwitched += new EventHandler(SetChatBatch);
            Listeners.ScoreBroadcast += new EventHandler(SetScoreBatch);
            LobbyView.LobbyViewInitialized += new EventHandler(ActivateLobbyState);
            MouseDown += Window_MouseDown;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        public string TurnBatch
        {
            get { return (string)GetValue(TurnBatchPropertyProperty); }
            set { SetValue(TurnBatchPropertyProperty, value); }
        }

        public static readonly DependencyProperty TurnBatchPropertyProperty =
            DependencyProperty.Register("TurnBatch", typeof(string), typeof(MainWindow), new PropertyMetadata("Content"));



        public string ChatBatch
        {
            get { return (string)GetValue(ChatBatchProperty); }
            set { SetValue(ChatBatchProperty, value); }
        }

        public static readonly DependencyProperty ChatBatchProperty =
            DependencyProperty.Register("ChatBatch", typeof(string), typeof(MainWindow), new PropertyMetadata("Content"));



        public string ScoreBatch
        {
            get { return (string)GetValue(ScoreBatchProperty); }
            set { SetValue(ScoreBatchProperty, value); }
        }

        public static readonly DependencyProperty ScoreBatchProperty =
            DependencyProperty.Register("ScoreBatch", typeof(string), typeof(MainWindow), new PropertyMetadata("Content"));



        public string OnlineBatch
        {
            get { return (string)GetValue(OnlineBatchProperty); }
            set { SetValue(OnlineBatchProperty, value); }
        }

        public static readonly DependencyProperty OnlineBatchProperty =
            DependencyProperty.Register("OnlineBatch", typeof(string), typeof(MainWindow), new PropertyMetadata("Content"));


        private void ActivateMatchState(Object IsRematch, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                LobbyGrid.Visibility = Visibility.Hidden;
                GameGrid.Visibility = Visibility.Visible;
                MatchmakingButton.Visibility = Visibility.Hidden;
                QuitButton.Visibility = Visibility.Visible;
                if ((bool)IsRematch) RematchBatchState.Visibility = Visibility.Visible;
                else GameBatchState.Visibility = Visibility.Visible;
                WaitingBatchState.Visibility = Visibility.Hidden;
                LobbyBatchState.Visibility = Visibility.Hidden;
            });
        }

        private void ActivateLobbyState(Object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                LobbyGrid.Visibility = Visibility.Visible;
                GameGrid.Visibility = Visibility.Hidden;
                MatchmakingButton.Visibility = Visibility.Visible;
                QuitButton.Visibility = Visibility.Hidden;
                LobbyBatchState.Visibility = Visibility.Visible;
                RematchBatchState.Visibility = Visibility.Hidden;
                GameBatchState.Visibility = Visibility.Hidden;
                WaitingBatchState.Visibility = Visibility.Hidden;
                DataContext = new LobbyViewModel();
            });
        }

        private void ActivateIsWaitingState(Object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                MatchmakingButton.Visibility = Visibility.Hidden;
                QuitButton.Visibility = Visibility.Visible;
                WaitingBatchState.Visibility = Visibility.Visible;
                LobbyBatchState.Visibility = Visibility.Hidden;
            });
        }

        private void MatchmakingButton_Click(object sender, EventArgs e)
        {
            Client.StartMatchmaking();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Client.Quit();
        }

        private void MatchmakingButton_Loaded(object sender, RoutedEventArgs e)
        {
            MatchmakingButtonControl o = (MatchmakingButtonControl)sender;
            o.MatchmakingButtonClicked += new EventHandler(MatchmakingButton_Click);
        }

        private void QuitButton_Loaded(object sender, RoutedEventArgs e)
        {
            QuitButtonControl o = (QuitButtonControl)sender;
            o.QuitButtonClicked += new EventHandler(QuitButton_Click);
        }

        private void SetTurnBatch(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                TurnBatch = (string)sender;
            });
        }

        private void SetChatBatch(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                ChatBatch = (string)sender;
            });
        }

        private void SetOnlineBatch(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                OnlineBatch = (string)sender;
            });
        }

        private void SetScoreBatch(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                ScoreBatch = (string)sender;
            });
        }
    }
}
