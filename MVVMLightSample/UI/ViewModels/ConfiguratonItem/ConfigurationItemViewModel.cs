using GalaSoft.MvvmLight;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces.ConfigureatonItem;

namespace UI.ViewModel.ConfigureatonItem
{
	public abstract class ConfigurationItemViewModel<T> : ViewModelBase, IConfigurationItemViewModel where T : IConfigurationItemModel
	{
		protected T _model { get; set; }
		public virtual void SetModel(T model)
		{
			_model = model;
			_model.ModelUpdateEvent += ModelUpdateEvent;
		}

		protected virtual void ModelUpdateEvent(object sender, ModelUpdateEventArgs e)
		{
			throw new System.NotImplementedException();
		}
	}
}
