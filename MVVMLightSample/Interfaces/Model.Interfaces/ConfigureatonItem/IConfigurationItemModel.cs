using System;
using Interfaces.EventArgument;

namespace Interfaces.Model.Interfaces.ConfigureatonItem
{
    public interface IConfigurationItemModel
    {
        void UiUpdate();
        event EventHandler<ModelUpdateEventArgs> ModelUpdateEvent;
    }
}