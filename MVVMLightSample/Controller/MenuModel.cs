using System.Collections.Generic;
using System.Diagnostics;
using Interfaces;
using Interfaces.Enum;
using Interfaces.Model.Interfaces;
using Interfaces.ViewModel.Interfaces;

namespace Controller
{
	internal class MenuModel : IMenuModel
	{
		private readonly IDisplayController _displayController;

		public MenuModel()
		{
			_displayController = ClassLocator.GetInstance<IDisplayController>();
			Debug.Assert(_displayController != null, "IDisplayController not found for MenuModel");

			MenuButtonCommands = new List<IButtonModel>()
			{
				new MenuButtonModel ("Home", (s, a) =>
				{
					_displayController.RevertDisplay();
				}),
				new MenuButtonModel ("About", (s, a) =>
				{
					_displayController.ChangeDisplay(typeof(IAboutViewModel), DisplayActionTypes.PushPreviousDisplay, true);
				}),
				new MenuButtonModel ("Configuraton", (s, a) =>
				{
					_displayController.ChangeDisplay(typeof(IConfigurationViewModel), DisplayActionTypes.PushPreviousDisplay, true);
				}),
			};
		}

		public IList<IButtonModel> MenuButtonCommands { get;}
	}
}
