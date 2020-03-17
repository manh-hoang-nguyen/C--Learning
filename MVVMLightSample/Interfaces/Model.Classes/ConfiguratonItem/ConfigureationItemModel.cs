using System;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces.ConfigureatonItem;

namespace Interfaces.Model.Classes.ConfigureatonItem
{
	public abstract class ConfigurationItemModel : IConfigurationItemModel
	{
		public virtual void UiUpdate() { }

		public event EventHandler<ModelUpdateEventArgs> ModelUpdateEvent;

		internal void ModelUpdate ()
		{
			ModelUpdateEvent?.Invoke(this, new ModelUpdateEventArgs());
		}
	}
}
