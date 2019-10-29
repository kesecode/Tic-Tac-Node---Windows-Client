using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Node__Windows_Client.UiComponent.Buttons
{
    /// <summary>
    /// Interaktionslogik für CloseButtonControl.xaml
    /// </summary>
    public partial class CloseButtonControl : UserControl
    {
        public CloseButtonControl()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
