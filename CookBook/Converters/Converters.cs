using Avalonia.Data.Converters;

namespace CookBook.Converters;
public static class Converters
{
    public static readonly IMultiValueConverter ChooseInteger = new ChooseIntegerConverter();
    public static readonly IMultiValueConverter BooleanToFontWeight = new BooleanToFontWeightConverter();
    public static readonly IMultiValueConverter BooleanToColor = new BooleanToColorConverter();
}

