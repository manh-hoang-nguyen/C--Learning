using System;
using Interfaces.Enum;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;

namespace UI.DesignViewSimulators
{
    internal class BottomBarModelSimulator : IBottomBarModel
    {
        public event EventHandler<UpdateEventArgs> UpdateEvent;
 
        public void MenuCommand(object sender, CommandArgs a)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserMessage(string message, MessageTypeEnum messageType)
        {
            throw new NotImplementedException();
        }

        public string UserMessage => "This is where the user will see status messages";
        public MessageTypeEnum MessageType => MessageTypeEnum.Warning;
    }
}