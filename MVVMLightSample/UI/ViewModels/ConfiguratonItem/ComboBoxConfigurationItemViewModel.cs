using System.Collections.Generic;
using Interfaces.Model.Interfaces.ConfigureatonItem;

namespace UI.ViewModel.ConfigureatonItem
{
	public class ComboBoxConfigurationItemViewModel : ConfigurationItemViewModel<IComboBoxConfigurationItemModel>
	{
		public string Label => _model.Label;

		public object Value
		{
			get { return _model.Value; }
			set
			{
				if (_model.Value != value)
				{
					_model.Value = value;
					_model.UiUpdate();
				}
			}
		}

		public IEnumerable<object> ItemsSource => _model.ItemsSource;
	}
}
