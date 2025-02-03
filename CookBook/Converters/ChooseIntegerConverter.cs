using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace CookBook.Converters;

/// <summary>
/// Choose one of two integres from arguments based on boolean values.
/// Argumets are boolean, int, and int.
/// First int is returned if boolean is true.
/// </summary>
internal class ChooseIntegerConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is bool check &&
            values[1] is string val1str &&
            values[2] is string val2str)
        {
            if (double.TryParse(val1str, out double val1) &&
                double.TryParse(val2str, out double val2))
                return check ? val1 : val2;
        }
        return Avalonia.AvaloniaProperty.UnsetValue;
    }
}

