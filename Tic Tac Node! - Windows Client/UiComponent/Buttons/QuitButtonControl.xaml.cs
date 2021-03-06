﻿using System;
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
    /// Interaktionslogik für QuitButtonControl.xaml
    /// </summary>
    public partial class QuitButtonControl : UserControl
    {
        public event EventHandler QuitButtonClicked;

        public QuitButtonControl()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            OnQuitButtonClick();
        }

        private void OnQuitButtonClick()
        {
            QuitButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
