using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

/// <summary>
/// Choose one of two font weights from arguments based on boolean values.
/// Argumets are boolean, FotnWeight, and FontWeight.
/// First FontWeight is returned if boolean is true.
/// </summary>
namespace CookBook.Converters;
public class BooleanToFontWeightConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is bool check &&
        values[1] is FontWeight val1 &&
        values[2] is FontWeight val2)
        {
            return check ? val1 : val2;
        }
        return Avalonia.AvaloniaProperty.UnsetValue;
    }
}

