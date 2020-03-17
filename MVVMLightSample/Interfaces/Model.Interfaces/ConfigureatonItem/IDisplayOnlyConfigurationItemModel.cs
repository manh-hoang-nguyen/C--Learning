namespace Interfaces.Model.Interfaces.ConfigureatonItem
{
    public interface IDisplayOnlyConfigurationItemModel : IConfigurationItemModel
	{
		string Label { get; }
		string Value { get; }
	}
}
