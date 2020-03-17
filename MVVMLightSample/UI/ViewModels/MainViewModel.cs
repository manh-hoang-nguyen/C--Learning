using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media.Animation;
using Interfaces;
using Interfaces.Model;
using UI.Assets.AbstractClasses;
using UI.Assets.Helpers;
using Interfaces.EventArgument;
using Interfaces.Enum;
using GalaSoft.MvvmLight.Command;
using Interfaces.Model.Interfaces;
using UI.DesignViewSimulators;

namespace UI.ViewModel
{
	public class MainViewModel : UiViewModelBase
	{
		private readonly IDisplayController _displayController;
		private readonly Stack<UiViewModelBase> _primaryDisplayStack = new Stack<UiViewModelBase>();

		private UiViewModelBase _PrimaryViewModel;
		private string _userMessage;
		private IBottomBarModel _bottomBarModel;
		private MessageTypeEnum _messageType;

		public MainViewModel()
		{
			PrimaryViewModel = new SplashScreenViewModel { DisposeOfAfterUse = true };

			if (this.IsInDesignMode)
			{
				_bottomBarModel = new BottomBarModelSimulator();
				_displayController = new DisplayControllerSimulator();
			}
			else
			{
				_displayController = ClassLocator.GetInstance<IDisplayController>();
				Debug.Assert(_displayController != null, nameof(IDisplayController) + " not found for " + GetType().Name);
				_displayController.ChangeDisplayEvent += DisplayChangeEventHandler;
				_bottomBarModel = ClassLocator.GetInstance<IBottomBarModel>();
				Debug.Assert(_bottomBarModel != null, nameof(IBottomBarModel) + " not found for " + GetType().Name);
				_bottomBarModel.UpdateEvent += UpdateUserMessageEventHandler;
			}
			UserMessage = _bottomBarModel.UserMessage;
			MessageType = _bottomBarModel.MessageType;
		}

		private void UpdateUserMessageEventHandler(object sender, UpdateEventArgs e)
		{
			UserMessage = _bottomBarModel.UserMessage;
			MessageType = _bottomBarModel.MessageType;
		}

		private void DisplayChangeEventHandler(object sender, ChangeDisplayEventArgs changeDisplayEventArgs)
		{
			//Should not be keeping (or using) previous display and disposing
			switch (changeDisplayEventArgs.DisplayActionType)
			{
				case DisplayActionTypes.PopPreviousDisplay:
					PrimaryViewModel = _primaryDisplayStack.Pop();
					return;
				case DisplayActionTypes.PushPreviousDisplay:
					_primaryDisplayStack.Push(PrimaryViewModel);
					break;
			}

			if (PrimaryViewModel.DisposeOfAfterUse && !(changeDisplayEventArgs.DisplayActionType == DisplayActionTypes.PushPreviousDisplay))
				PrimaryViewModel.Cleanup();
			PrimaryViewModel = changeDisplayEventArgs.ViewModel();
		}

		public UiViewModelBase PrimaryViewModel
		{
			get { return _PrimaryViewModel; }
			set { Set(ref _PrimaryViewModel, value); }
		}

		public string UserMessage
		{
			get { return _userMessage; }
			set { Set(ref _userMessage, value); }
		}

		public MessageTypeEnum MessageType
		{
			get { return _messageType; }
			set { Set(ref _messageType, value); }
		}

		public RelayCommand MenuCommand => new RelayCommand(() => _bottomBarModel.MenuCommand(this, new CommandArgs()));

		public override void Cleanup()
		{
			_displayController.ChangeDisplayEvent -= DisplayChangeEventHandler;
			_bottomBarModel.UpdateEvent -= UpdateUserMessageEventHandler;
			while (_primaryDisplayStack.Count > 0)
				_primaryDisplayStack.Pop().Cleanup();
		}
	}
}
