using System;
using Interfaces.Enum;
using Interfaces.EventArgument;

namespace Interfaces.Model.Interfaces
{
    public interface IBottomBarModel
    {
        event EventHandler<UpdateEventArgs> UpdateEvent;
        void UpdateUserMessage(string message, MessageTypeEnum messageType);
        void MenuCommand(object sender, CommandArgs a);
        string UserMessage { get; }
        MessageTypeEnum MessageType { get; }
    }
}