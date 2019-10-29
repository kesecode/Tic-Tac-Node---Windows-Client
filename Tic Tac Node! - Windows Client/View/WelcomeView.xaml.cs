using System.Windows;
using System.Windows.Controls;
using Tic_Tac_Node__Windows_Client.Model;
using Tic_Tac_Node__Windows_Client.ViewModel;

namespace Tic_Tac_Node__Windows_Client.View
{
    /// <summary>
    /// Interaktionslogik für WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.Close();
        }

        private void NameSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Client.EmitUsername(UsernameField.Text);
            System.Windows.Application.Current.MainWindow.DataContext = new LobbyViewModel();
        }
    }
}
