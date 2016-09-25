using System;
using Xamarin.Forms;
namespace WhosOnBreak
{
	public class IntToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			//convert my int values of time into string to display
			double time = (double)value;
			int hour = (int)(time/1);
			if (((time) % 1.0).Equals(0.5))
			{
				return hour.ToString() + ":30";
			}
			else
			{
				return hour.ToString() + ":00";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}