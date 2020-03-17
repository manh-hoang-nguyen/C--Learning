using System.Collections.Generic;
using Interfaces.Model.Interfaces.ConfigureatonItem;
using System.Linq;

namespace Interfaces.Model.Classes.ConfigureatonItem
{
    public class ComboBoxConfigurationItemModel : ConfigurationItemModel, IComboBoxConfigurationItemModel
    {
        public ComboBoxConfigurationItemModel(string label, IEnumerable<object> itemsSource, string value)
        {
            Label = label;
            Value = value;
			ItemsSource = itemsSource.ToList();
        }


        public string Label { get; }
        public IList<object> ItemsSource { get; }
        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}