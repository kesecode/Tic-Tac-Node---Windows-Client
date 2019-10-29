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

namespace Tic_Tac_Node__Windows_Client.UiComponent.Chat.ChatComponent
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class ResultItemControl : UserControl
    {
        public ResultItemControl()
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            Client.EmitPlayAgainRequest();
        }

        private void RevancheButton_Click(object sender, RoutedEventArgs e)
        {
            Client.EmitRevancheRequest();
        }
    }
}
