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
using Tic_Tac_Node__Windows_Client.Model;
using Tic_Tac_Node__Windows_Client.UiComponent.Buttons;

namespace Tic_Tac_Node__Windows_Client.UiComponent.Chat.ChatComponent
{
    /// <summary>
    /// Interaktionslogik für ChatInputControl.xaml
    /// </summary>
    public partial class ChatInputControl : UserControl
    {
        private string input { get; set; }

        public ChatInputControl()
        {
            InitializeComponent();
            ChatSubmitButton.ChatSubmitButtonClicked += new EventHandler(submitText);
        }

        private void ChatInput_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            string recentInput = e.Text;
            if (recentInput == "\r") recentInput = "";
            input = ChatInput.Text + recentInput;
        }

        public void submitText(object sender, EventArgs e)
        {
            Client.SendMessage(input);
            ChatInput.Clear();
        }
    }
}
