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
    /// Interaktionslogik für OnlineBatchControl.xaml
    /// </summary>
    public partial class OnlineBatchControl : UserControl
    {


        public string OnlineBatchContent
        {
            get { return (string)GetValue(OnlineBatchContentProperty); }
            set { SetValue(OnlineBatchContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnlineBatchContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnlineBatchContentProperty =
            DependencyProperty.Register("OnlineBatchContent", typeof(string), typeof(OnlineBatchControl), new PropertyMetadata("Default"));



        public OnlineBatchControl()
        {
            InitializeComponent();
        }
    }
}
