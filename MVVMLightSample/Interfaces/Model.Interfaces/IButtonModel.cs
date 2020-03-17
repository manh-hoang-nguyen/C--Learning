using System;
using Interfaces.EventArgument;

namespace Interfaces.Model.Interfaces
{
	public interface IButtonModel
	{
		string Title { get; }
		EventHandler<CommandArgs> CommandHandler { get; }
	}
}