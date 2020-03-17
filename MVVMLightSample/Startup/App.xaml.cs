using System.Windows;

namespace Startup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Controller.StartUp _controllerStartUp;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _controllerStartUp = new Controller.StartUp();
            _controllerStartUp.Initialized += (sender, args) => 
            {
                UI.Startup.Initialize();
            };
            _controllerStartUp.Initialize();
        }
    }
}
