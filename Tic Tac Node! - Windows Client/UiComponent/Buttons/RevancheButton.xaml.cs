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

namespace Tic_Tac_Node__Windows_Client.UiComponent.Buttons
{
    /// <summary>
    /// Interaktionslogik für RevancheButton.xaml
    /// </summary>
    public partial class RevancheButton : UserControl
    {
        public RevancheButton()
        {
            InitializeComponent();
        }

        private void Revanche_Click(object sender, RoutedEventArgs e)
        {
            Client.EmitRevancheRequest();
        }
    }
}
