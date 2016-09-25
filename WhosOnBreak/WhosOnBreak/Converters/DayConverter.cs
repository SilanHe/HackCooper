using System;
using Xamarin.Forms;
namespace WhosOnBreak
{
	public class DayConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int day = (int)value;
			switch (day)
			{
				case (1):
					return "Monday";
				case (2):
					return "Tuesday";
				case (3):
					return "Wednesday";
				case (4):
					return "Thursday";
				case (5):
					return "Friday";
				case (6):
					return "Saturday";
				case (7):
					return "Sunday";
				default:
					return "rip";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}

}
