using System;
using Interfaces.Enum;
using Interfaces.EventArgument;

namespace Interfaces.Model.Interfaces
{
	public interface IDisplayController
	{
		event EventHandler<ChangeDisplayEventArgs> ChangeDisplayEvent;
		void ChangeDisplay(Type displayViewModelInterface, bool createNew = false);

		void ChangeDisplay(Type viewModelInterface, DisplayActionTypes displayAction,
			bool createNew = false);

		void RevertDisplay();
	}
}
