using System;
using System.Globalization;
using System.Windows.Data;

namespace TestingWPF.Converters;

public class HalfConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double)
        {
            return (double)value / 2;
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
