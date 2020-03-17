using System.Diagnostics;
using Interfaces;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;

namespace Controller
{
	internal class AboutModel : IAboutModel
	{
		private readonly IDisplayController _displayController;

		public AboutModel()
		{
			_displayController = ClassLocator.GetInstance<IDisplayController>();
			Debug.Assert(_displayController != null, "IDisplayController not found for AboutModel");

		}

		public void AboutOkCommand(object sender, CommandArgs a)
		{
			_displayController.RevertDisplay();
		}
	}
}
