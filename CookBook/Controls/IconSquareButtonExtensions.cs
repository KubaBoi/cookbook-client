using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Immutable;

namespace CookBook.Controls;
public static class IconSquareButtonExtensions
{
    // Path
    public static readonly AttachedProperty<Geometry> PathDataProperty =
        AvaloniaProperty.RegisterAttached<Button, Geometry>("PathData",
                                                            typeof(IconSquareButtonExtensions));
    public static void SetPathData(AvaloniaObject element, Geometry value) => element.SetValue(PathDataProperty, value);
    public static Geometry GetPathData(AvaloniaObject element) => element.GetValue(PathDataProperty);

    // Path width
    public static readonly AttachedProperty<double> PathWidthProperty =
        AvaloniaProperty.RegisterAttached<Button, double>("PathWidth",
                                                       typeof(IconSquareButtonExtensions),
                                                       20);
    public static void SetPathWidth(AvaloniaObject element, double value) => element.SetValue(PathWidthProperty, value);
    public static double GetPathWidth(AvaloniaObject element) => element.GetValue(PathWidthProperty);


    // Path height
    public static readonly AttachedProperty<double> PathHeightProperty =
        AvaloniaProperty.RegisterAttached<Button, double>("PathHeight",
                                                       typeof(IconSquareButtonExtensions),
                                                       20);
    public static void SetPathHeight(AvaloniaObject element, double value) => element.SetValue(PathHeightProperty, value);
    public static double GetPathHeight(AvaloniaObject element) => element.GetValue(PathHeightProperty);

    // StrokeThichness
    public static readonly AttachedProperty<double> PathStrokeThicknessProperty =
        AvaloniaProperty.RegisterAttached<Button, double>("PathStrokeThickness",
                                                          typeof(IconSquareButtonExtensions),
                                                          4);
    public static void SetPathStrokeThickness(AvaloniaObject element, double value) => element.SetValue(PathStrokeThicknessProperty, value);
    public static double GetPathStrokeThickness(AvaloniaObject element) => element.GetValue(PathStrokeThicknessProperty);

    // IconColor
    public static readonly AttachedProperty<ImmutableSolidColorBrush> IconColorProperty =
        AvaloniaProperty.RegisterAttached<Button, ImmutableSolidColorBrush>("IconColor",
                                                                   typeof(IconSquareButtonExtensions), //FF3f4e4f
                                                                   new ImmutableSolidColorBrush(new Color(255, 63, 78, 79)));
    public static void SetIconColor(AvaloniaObject element, ImmutableSolidColorBrush value) => element.SetValue(IconColorProperty, value);
    public static ImmutableSolidColorBrush GetIconColor(AvaloniaObject element) => element.GetValue(IconColorProperty);
}
