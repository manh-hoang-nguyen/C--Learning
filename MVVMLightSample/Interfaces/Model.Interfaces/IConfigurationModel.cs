using System.Collections.Generic;
using Interfaces.Model.Classes.ConfigureatonItem;

namespace Interfaces.Model.Interfaces
{
	public interface IConfigurationModel
	{
		IList<ConfigurationItemModel> ConfigurationItems { get; }
	}
}
