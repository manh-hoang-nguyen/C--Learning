using System;
using System.Collections.Generic;
using System.Diagnostics;
using Interfaces.Enum;

namespace Interfaces.EventArgument
{
	public class ChangeDisplayEventArgs
	{
		public static readonly Dictionary<Type, Type> InterfaceTypeDictionary = new Dictionary<Type, Type>();

		public ChangeDisplayEventArgs(Type displayViewModelInterface, bool createNew = false) :
			this(displayViewModelInterface, DisplayActionTypes.Replace, createNew)
		{		}

		public ChangeDisplayEventArgs(Type viewModelInterface, DisplayActionTypes displayAction, bool createNew = false)
		{
			ViewModelInterface = viewModelInterface;
			Debug.Assert(displayAction != DisplayActionTypes.PopPreviousDisplay || viewModelInterface == null,
				"PopPreviousDisplay requested with a specification of  DisplayViewModelInterface");
			DisplayActionType = displayAction;
			CreateNew = createNew;
		}

		/// <summary>
		/// This is used to just pop the previous display
		/// </summary>
		public ChangeDisplayEventArgs()
		{
			DisplayActionType = DisplayActionTypes.PopPreviousDisplay;
		}

		public Type ViewModelInterface { get; }

		public DisplayActionTypes DisplayActionType { get; }

		public bool CreateNew { get; }
	}
}