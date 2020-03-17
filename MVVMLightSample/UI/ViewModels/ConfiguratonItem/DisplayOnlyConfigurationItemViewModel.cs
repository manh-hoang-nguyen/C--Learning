using Interfaces.Model.Interfaces.ConfigureatonItem;

namespace UI.ViewModel.ConfigureatonItem
{
	public class DisplayOnlyConfigurationItemViewModel : ConfigurationItemViewModel<IDisplayOnlyConfigurationItemModel>
	{
		public string Label => _model.Label;

		public string Value => _model.Value;
	}
}
