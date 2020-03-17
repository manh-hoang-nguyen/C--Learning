using System.Collections.ObjectModel;
using Interfaces;
using System.Diagnostics;
using System.Linq;
using UI.Assets.AbstractClasses;
using System;
using System.Collections.Generic;
using Interfaces.Model.Classes.ConfigureatonItem;
using Interfaces.Model.Interfaces;
using Interfaces.ViewModel.Interfaces;
using UI.Assets.Helpers;
using UI.ViewModel.ConfigureatonItem;

namespace UI.ViewModel
{
    public class ConfigurationViewModel : UiViewModelBase, IConfigurationViewModel
    {
        private readonly IConfigurationModel _configurationModel;

        public ConfigurationViewModel()
        {
            if (this.IsInDesignMode)
            {
                _configurationModel = new ConfigurationModelSimulator();
            }
            else
            {
                _configurationModel = ClassLocator.GetInstance<IConfigurationModel>();
                Debug.Assert(_configurationModel != null, "INavigateCommands not found for AboutViewModel");
            }
			ConfigurationItems = new ObservableCollection<IConfigurationItemViewModel>();
            _configurationModel.ConfigurationItems.ToList().ForEach(i => ConfigurationItems.Add(ViewModelHelpers.GetConfigurationItemViewModel(i)));
        }

        public ObservableCollection<IConfigurationItemViewModel> ConfigurationItems { get; }

    }

	internal class ConfigurationModelSimulator : IConfigurationModel
	{
		public ConfigurationModelSimulator()
		{
			ConfigurationItems = new List<ConfigurationItemModel>()
			{
				new DisplayOnlyConfigurationItemModel ("Time", DateTime.Now.ToShortTimeString()),
				new DisplayOnlyConfigurationItemModel ("Event Happened", "unknown"),
				new ComboBoxConfigurationItemModel ("Type", new[] {"Alpha", "Beta", "Gamma" }, "Alpha")
			};
		}

		public IList<ConfigurationItemModel> ConfigurationItems { get; }
	}
}
