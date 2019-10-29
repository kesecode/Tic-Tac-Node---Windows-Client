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
    /// Interaktionslogik für ScoreBatchControl.xaml
    /// </summary>
    public partial class ScoreBatchControl : UserControl
    {
        public string ScoreBatchContent
        {
            get { return (string)GetValue(ScoreBatchContentProperty); }
            set { SetValue(ScoreBatchContentProperty, value); }
        }

        public static readonly DependencyProperty ScoreBatchContentProperty =
            DependencyProperty.Register("ScoreBatchContent", typeof(string), typeof(ScoreBatchControl), new PropertyMetadata("Default"));

        public ScoreBatchControl()
        {
            InitializeComponent();
        }
    }
}
