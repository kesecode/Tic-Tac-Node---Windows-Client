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

namespace Tic_Tac_Node__Windows_Client.UiComponent.Batches
{
    /// <summary>
    /// Interaktionslogik für ChatroomBatchControl.xaml
    /// </summary>
    public partial class ChatroomBatchControl : UserControl
    {


        public string ChatroomBatchContent
        {
            get { return (string)GetValue(ChatroomBatchContentProperty); }
            set { SetValue(ChatroomBatchContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChatroomBatchContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChatroomBatchContentProperty =
            DependencyProperty.Register("ChatroomBatchContent", typeof(string), typeof(ChatroomBatchControl), new PropertyMetadata("Default"));



        public ChatroomBatchControl()
        {
            InitializeComponent();
        }
    }
}
