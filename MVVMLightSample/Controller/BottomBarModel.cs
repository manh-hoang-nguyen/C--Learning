using System;
using System.Diagnostics;
using Interfaces;
using Interfaces.Enum;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;
using Interfaces.ViewModel.Interfaces;

namespace Controller
{
	internal class BottomBarModel : IBottomBarModel
	{
		private readonly IDisplayController _displayController;

		public BottomBarModel()
		{
			_displayController = ClassLocator.GetInstance<IDisplayController>();
			Debug.Assert(_displayController != null, "IDisplayController not found for BottomBarModel");
		    UserMessage = "Initializing...";
            MessageType = MessageTypeEnum.Information;
		}

		public void MenuCommand(object sender, CommandArgs a)
		{
			_displayController.ChangeDisplay(typeof(IMenuViewModel), DisplayActionTypes.PushPreviousDisplay, true);
		}

		public void UpdateUserMessage(string message, MessageTypeEnum messageType)
		{
		    UserMessage = message;
		    MessageType = messageType;
            UpdateEvent?.Invoke(this, new UpdateEventArgs());
		}

		public event EventHandler<UpdateEventArgs> UpdateEvent;
	    public string UserMessage { get; private set; }
	    public MessageTypeEnum MessageType { get; private set; }
	}
}
