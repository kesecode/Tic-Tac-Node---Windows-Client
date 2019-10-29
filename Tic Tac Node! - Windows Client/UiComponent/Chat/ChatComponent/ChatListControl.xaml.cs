using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using Tic_Tac_Node__Windows_Client.Model;

namespace Tic_Tac_Node__Windows_Client.UiComponent.Chat.ChatComponent
{
    /// <summary>
    /// Interaktionslogik für ChatListControl.xaml
    /// </summary>
    public partial class ChatListControl : UserControl
    {
        public BindableCollection<JsonModel.Message> Messages { get; set; }

        public ChatListControl()
        {
            InitializeComponent();
            Messages = new BindableCollection<JsonModel.Message>();
            Items.ItemsSource = MessageList.Messages;
        }
    }
}
