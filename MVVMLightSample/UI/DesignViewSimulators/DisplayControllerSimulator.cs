using System;
using Interfaces.Enum;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;

namespace UI.DesignViewSimulators
{
    internal class DisplayControllerSimulator : IDisplayController
    {
		public event EventHandler<ChangeDisplayEventArgs> ChangeDisplayEvent;

		public void AboutOkCommand(object sender, CommandArgs a)
        {
            throw new NotImplementedException();
        }

		public void ChangeDisplay(Type displayViewModelInterface, bool createNew = false)
		{
			throw new NotImplementedException();
		}

		public void ChangeDisplay(Type viewModelInterface, DisplayActionTypes displayAction, bool createNew = false)
		{
			throw new NotImplementedException();
		}

		public void RevertDisplay()
		{
			throw new NotImplementedException();
		}
	}
}