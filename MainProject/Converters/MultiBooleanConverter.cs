using System;
using System.Globalization;
using System.Windows.Data;

namespace TestingWPF.Converters;

public class MultiBooleanConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        foreach (object value in values)
        {
            if (value is bool boolValue && !boolValue)
            {
                return false; // Disable the button if any condition is false
            }
        }
        return true; // Enable the button if all conditions are true
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}