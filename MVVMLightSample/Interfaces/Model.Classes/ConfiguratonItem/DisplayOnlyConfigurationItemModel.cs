using Interfaces.Model.Interfaces.ConfigureatonItem;

namespace Interfaces.Model.Classes.ConfigureatonItem
{
    public class DisplayOnlyConfigurationItemModel : ConfigurationItemModel, IDisplayOnlyConfigurationItemModel
    {
        public DisplayOnlyConfigurationItemModel(string label, string value)
        {
            Label = label;
            Value = value;
        }

        public string Label { get; }
        public string Value { get; }
    }
}