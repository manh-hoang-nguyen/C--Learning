using System;
using System.Collections.Generic;
using Interfaces.Model.Classes.ConfigureatonItem;
using Interfaces.Model.Interfaces;

namespace Controller
{
	internal class ConfigurationModel : IConfigurationModel
	{
		public ConfigurationModel()
		{
			ConfigurationItems = new List<ConfigurationItemModel>()
			{
				new DisplayOnlyConfigurationItemModel ("Time", DateTime.Now.ToShortTimeString()),
				new ComboBoxConfigurationItemModel ("Type", new[] {"Alpha", "Beta", "Gamma" }, "Alpha"),
				new DisplayOnlyConfigurationItemModel ("Type", "unknown"),
			};
		}

		public IList<ConfigurationItemModel> ConfigurationItems { get; }
	}
}
