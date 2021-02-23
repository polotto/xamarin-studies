using System;
using System.Globalization;
using Xamarin.Forms;

namespace todo
{
    public class BoolToColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Color.FromHex("#20A4B4");
            } else
            {
                return Color.FromHex("#3988F1");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
