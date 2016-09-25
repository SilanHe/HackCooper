using System;
using Xamarin.Forms;
namespace WhosOnBreak
{
	public class BreakToColorConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int isBreaks = (int)value;

			if (isBreaks == 1)//isBreak=true but IsCommon=false
				return Color.Green;
			else if (isBreaks == 2)//isBreak=true and IsCommon=true
				return Color.Blue;
			else//IsBreak=false and IsCommon=false
				return Color.White;
			
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
