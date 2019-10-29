using System.Windows;
using XamlCSS.WPF;
using Tic_Tac_Node__Windows_Client.Model;


namespace Tic_Tac_Node__Windows_Client
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class Application : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            XamlCSS.WPF.Css.Initialize();
            base.OnStartup(e);
        }
    }
}
