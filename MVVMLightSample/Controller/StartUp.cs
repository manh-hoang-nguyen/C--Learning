using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Enum;
using Interfaces.Model.Interfaces;
using Interfaces.ViewModel.Classes;

namespace Controller
{
	public class StartUp
	{
        private IDisplayController _displayController;
        private IBottomBarModel _bottomBarModel;

        public StartUp()
		{
        }

        public async void Initialize()
		{
            ClassLocator.Register<IDisplayController>(() => new DisplayController());
            ClassLocator.Register<IBottomBarModel>(() => new BottomBarModel());
			_displayController = ClassLocator.GetInstance<IDisplayController>();
			_bottomBarModel = ClassLocator.GetInstance<IBottomBarModel>();
			Debug.Assert(_displayController != null, "IDisplayController not found for BackEndSimulator");
			Debug.Assert(_bottomBarModel != null, "IBottomBarModel not found for BackEndSimulator");

            ClassLocator.Register<IMenuModel>(() => new MenuModel());
            ClassLocator.Register<IAboutModel>(() => new AboutModel());
            ClassLocator.Register<IConfigurationModel>(() => new ConfigurationModel());

            Initialized?.Invoke(this, new InitializedEventArgs());

			await Task.Run(() =>
			{
			    Thread.Sleep(10000);
               _bottomBarModel.UpdateUserMessage("10 seconds have passed", MessageTypeEnum.Warning);
			  // _displayController.ChangeDisplay(typeof(IAboutViewModel), true);
		   });
		}

	    public event EventHandler<InitializedEventArgs> Initialized;
	}
}
