using System.Collections.ObjectModel;
using Interfaces;
using System.Diagnostics;
using System.Linq;
using Interfaces.Model.Interfaces;
using Interfaces.ViewModel.Interfaces;
using UI.Assets.AbstractClasses;
using UI.DesignViewSimulators;

namespace UI.ViewModel
{
    public class MenuViewModel : UiViewModelBase, IMenuViewModel
    {
        private readonly IMenuModel _menuModel;

        public MenuViewModel()
        {
            if (this.IsInDesignMode)
            {
                _menuModel = new MenuModelSimulator();
            }
            else
            {
                _menuModel = ClassLocator.GetInstance<IMenuModel>();
                Debug.Assert(_menuModel != null, "INavigateCommands not found for AboutViewModel");
            }
            Buttons = new ObservableCollection<ButtonViewModel>();
            _menuModel.MenuButtonCommands.ToList().ForEach(i => Buttons.Add(new ButtonViewModel(i)));
        }

        public ObservableCollection<ButtonViewModel> Buttons { get; }
    }
}
