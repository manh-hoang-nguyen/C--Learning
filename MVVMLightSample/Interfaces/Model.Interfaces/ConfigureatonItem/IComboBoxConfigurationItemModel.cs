using System.Collections.Generic;

namespace Interfaces.Model.Interfaces.ConfigureatonItem
{
    public interface IComboBoxConfigurationItemModel : IConfigurationItemModel
	{
		string Label { get; }
		IList<object> ItemsSource { get; }
		object Value { get; set; }
	}
}
