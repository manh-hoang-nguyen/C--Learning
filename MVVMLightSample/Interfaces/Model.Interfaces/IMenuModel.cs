using System.Collections.Generic;

namespace Interfaces.Model.Interfaces
{
	public interface IMenuModel
	{
		IList<IButtonModel> MenuButtonCommands { get; }
	}
}
