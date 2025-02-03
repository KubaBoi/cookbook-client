using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Converters;
public static class Converters
{
    public static readonly IMultiValueConverter ChooseInteger = new ChooseIntegerConverter();
    public static readonly IMultiValueConverter BooleanToFontWeight = new BooleanToFontWeightConverter();
    public static readonly IMultiValueConverter BooleanToColor = new BooleanToColorConverter();
}

