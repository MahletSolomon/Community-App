﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestingWPF.Converters;

public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue && targetType == typeof(Visibility))
        {
            return boolValue ? Visibility.Collapsed : Visibility.Visible;
        }

        throw new ArgumentException("Invalid conversion or targetType");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}