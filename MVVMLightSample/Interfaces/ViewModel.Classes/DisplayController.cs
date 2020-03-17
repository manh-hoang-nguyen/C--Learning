using System;
using GalaSoft.MvvmLight.Threading;
using Interfaces.Enum;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;

namespace Interfaces.ViewModel.Classes
{
	public class DisplayController : IDisplayController
	{
		public event EventHandler<ChangeDisplayEventArgs> ChangeDisplayEvent;

		public void ChangeDisplay(Type viewModelInterface, bool createNew = false)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(()=>
			ChangeDisplayEvent?.Invoke(this, new ChangeDisplayEventArgs(viewModelInterface, createNew)));
		}

		public void ChangeDisplay(Type viewModelInterface, DisplayActionTypes displayAction, bool createNew = false)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(()=>
			ChangeDisplayEvent?.Invoke(this, new ChangeDisplayEventArgs(viewModelInterface, displayAction, createNew)));
		}

		public void RevertDisplay()
		{
			DispatcherHelper.CheckBeginInvokeOnUI(()=>
			ChangeDisplayEvent?.Invoke(this, new ChangeDisplayEventArgs()));
		}
	}
}
