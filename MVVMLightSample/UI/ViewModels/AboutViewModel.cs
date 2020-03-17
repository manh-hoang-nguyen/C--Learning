using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using Interfaces;
using UI.Assets.AbstractClasses;
using UI.Assets.Helpers;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;
using Interfaces.ViewModel.Interfaces;
using UI.DesignViewSimulators;

namespace UI.ViewModel
{
	public class AboutViewModel : UiViewModelBase, IAboutViewModel
	{
		private IAboutModel _aboutModel;

		public AboutViewModel()
		{
			if (this.IsInDesignMode)
			{
                _aboutModel = new AboutModelSimulator();
			}
			else
			{
                _aboutModel = ClassLocator.GetInstance<IAboutModel>();
				Debug.Assert(_aboutModel != null, "IAboutModel not found for AboutViewModel");
			}
		}

		public string Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

		public string Copyright => GeneralHelpers.GetCopyright();

		public RelayCommand OkCommand => new RelayCommand(() => _aboutModel.AboutOkCommand(this, new CommandArgs()));

	    public override void Cleanup()
	    {
	        _aboutModel = null;
	        base.Cleanup();
	    }
	}
}
