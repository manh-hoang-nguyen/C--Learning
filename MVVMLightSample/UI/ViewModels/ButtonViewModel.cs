using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using Interfaces.EventArgument;
using Interfaces.Model.Interfaces;

namespace UI.ViewModel
{
	public class ButtonViewModel
	{
	    private readonly IButtonModel _buttonCommand;

	    public ButtonViewModel(IButtonModel menuButtonModel)
        {
            _buttonCommand = menuButtonModel;
            Debug.Assert(menuButtonModel != null, "IButtonModel cannot be null");
        }

	    public string Title => _buttonCommand.Title;

        public RelayCommand ButtonCommand => new RelayCommand(() => _buttonCommand.CommandHandler(this, new CommandArgs()));

        public override string ToString()
        {
            return $"MenuButtonViewModel: {Title}";
        }
    }
}