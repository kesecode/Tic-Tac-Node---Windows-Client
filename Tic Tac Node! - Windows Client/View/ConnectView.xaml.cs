using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Quobject.SocketIoClientDotNet.Client;
using Tic_Tac_Node__Windows_Client.Model;
using Tic_Tac_Node__Windows_Client.ViewModel;

namespace Tic_Tac_Node__Windows_Client.View
{
    /// <summary>
    /// Interaktionslogik für ConnectView.xaml
    /// </summary>
    public partial class ConnectView : UserControl
    {
        private string address { get; set; }
        bool isConnected = false;
        Socket socket;

        

        public ConnectView()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            initializeSocket();

            System.Threading.Thread.Sleep(200);

            if (isConnected)
            {
                Application.Current.MainWindow.DataContext = new WelcomeViewModel();
            }
            else
            {
                initializeSocket();
                System.Threading.Thread.Sleep(200);
            }
            if (isConnected)
            {
                Application.Current.MainWindow.DataContext = new WelcomeViewModel();
            }
        }

        private void initializeSocket()
        {
            socket = IO.Socket(@"https://www.tictacnode.de/");
            System.Threading.Thread.Sleep(300);
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                isConnected = true;
                new Client(socket);
            });
        }
    }
}
