using System;
using Xamarin.Forms;
namespace WhosOnBreak
{
	public class BreakToColorConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool isBreak = (bool)value;
			return isBreak? Color.Green: Color.Red;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
