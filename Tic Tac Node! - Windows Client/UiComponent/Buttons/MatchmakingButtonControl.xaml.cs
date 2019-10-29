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

namespace Tic_Tac_Node__Windows_Client.UiComponent.Buttons
{
    /// <summary>
    /// Interaktionslogik für MatchmakingButtonControl.xaml
    /// </summary>
    public partial class MatchmakingButtonControl : UserControl
    {
        public event EventHandler MatchmakingButtonClicked;

        public MatchmakingButtonControl()
        {
            InitializeComponent();
        }

        private void MatchmakingButton_Click(object sender, RoutedEventArgs e)
        {
            OnMatchmakingButtonClick();
        }

        private void OnMatchmakingButtonClick()
        {
            MatchmakingButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
