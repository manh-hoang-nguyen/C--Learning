using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using Interfaces.Enum;
using System.Windows.Media;

namespace Interfaces.Assets.Converters
{
	public class MessagetTypeToBackgroundBrushConverter : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Debug.Assert(value ==null || value is MessageTypeEnum, "MessagetTypeToBrushConverter value argument not of type MessageTypeEnum");
			if (value == null) return new SolidColorBrush(Colors.LightBlue);
			var messageType = (MessageTypeEnum) value;
			switch (messageType)
			{
				case MessageTypeEnum.Warning:
					return new SolidColorBrush(Colors.Yellow); ;
				case MessageTypeEnum.Error:
					return new SolidColorBrush(Colors.Red);
				case MessageTypeEnum.Information:
					return new SolidColorBrush(Colors.LightGreen);
				default:
					throw new ArgumentOutOfRangeException();
			}	
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
