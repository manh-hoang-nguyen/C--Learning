using System.Reflection;

namespace UI.Assets.Helpers
{
	public static class GeneralHelpers
	{
		public static string GetCopyright()
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			object[] obj = asm.GetCustomAttributes(false);
			foreach (object o in obj)
			{
				if (o.GetType() == typeof(System.Reflection.AssemblyCopyrightAttribute))
				{
					AssemblyCopyrightAttribute aca = (AssemblyCopyrightAttribute)o;
					return aca.Copyright;
				}
			}
			return string.Empty;
		}
	}
}
