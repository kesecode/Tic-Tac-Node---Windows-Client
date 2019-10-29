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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tic_Tac_Node__Windows_Client.UiComponent.Chat.ChatComponent;

namespace Tic_Tac_Node__Windows_Client.UiComponent.Buttons
{
    /// <summary>
    /// Interaktionslogik für SubmitButtonControl.xaml
    /// </summary>
    public partial class ChatSubmitButtonControl : UserControl
    {
        public event EventHandler ChatSubmitButtonClicked;

        public ChatSubmitButtonControl()
        {
            InitializeComponent();
        }

        private void OnChatSubmitButtonClick()
        {
            ChatSubmitButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ChatSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            OnChatSubmitButtonClick();
        }
    }
}
