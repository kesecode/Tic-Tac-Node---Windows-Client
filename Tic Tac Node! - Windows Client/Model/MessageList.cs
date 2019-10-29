using Tic_Tac_Node__Windows_Client.JsonModel;
using Caliburn.Micro;
using Message = Tic_Tac_Node__Windows_Client.JsonModel.Message;

namespace Tic_Tac_Node__Windows_Client.Model
{
    static class MessageList 
    {
        static public BindableCollection<Message> Messages { get; set; } = new BindableCollection<Message>();


        static MessageList()
        {
        }

        static public void Add(Message message)
        {
            Messages.Add(message);
        }
        
        static public void Clear()
        {
            Messages.Clear();
        }
    }
}
