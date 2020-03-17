using System.Windows;
using Controller;
using GalaSoft.MvvmLight.Threading;
using Interfaces;
using Interfaces.Model;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Controller.StartUp _controllerStartUp;

        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherHelper.Initialize();
            //This one need to be registered immediately so that the 
            ClassLocator.Register<IDisplayController>(() => new DisplayController());
            ClassLocator.Register<IBottomBarModel>(() => new BottomBarModel());

            _controllerStartUp = new StartUp();
            _controllerStartUp.Initialized += (sender, args) =>
            {

            };
            _controllerStartUp.Initialize();
        }
    }
}
