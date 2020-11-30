using System;
using Xamarin.Forms;

namespace demoApp.Utils.Converters
{
    public class Inverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return false;

            bool bReturn = !System.Convert.ToBoolean(value);
            return bReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
