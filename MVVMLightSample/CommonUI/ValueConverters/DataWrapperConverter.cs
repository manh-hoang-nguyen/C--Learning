using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CommonUI.ValueConverters
{
	public class DataWrapperConverter : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is IEnumerable)
			{
				var returnValue = new List<DataWrapper>();
				foreach (var i in ((IEnumerable)value))
					returnValue.Add(new DataWrapper(i));
				return returnValue;
			}
			return new DataWrapper(value);
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

	public class DataWrapper
	{
		public DataWrapper(object data)
		{
			Data = data;
		}
		public object Data { get; }
	}
}
