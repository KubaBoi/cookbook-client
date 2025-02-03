using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CookBook.Converters;
internal class BooleanToColorConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is bool check)
        {
            Color? TryGetColor(object? value)
            {
                if (value is Color color)
                    return color;

                if (value is SolidColorBrush brush)
                    return brush.Color;

                if (value is ImmutableSolidColorBrush immutableBrush)
                    return immutableBrush.Color;

                if (value is string hexString && Color.TryParse(hexString, out var parsedColor))
                    return parsedColor;

                return null;
            }

            var color1 = TryGetColor(values[1]);
            var color2 = TryGetColor(values[2]);

            if (color1 != null && color2 != null)
            {
                return new SolidColorBrush(check ? color1.Value : color2.Value);
            }
        }
        return Avalonia.AvaloniaProperty.UnsetValue;
    }
}

