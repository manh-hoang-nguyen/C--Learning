namespace Interfaces.EventArgument
{
	public class CommandArgs
	{
		public CommandArgs(object commandParameter = null)
		{
			CommandParameter = commandParameter;
		}
		public object CommandParameter { get; }
	}
}