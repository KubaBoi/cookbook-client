using Avalonia.Controls;
using Avalonia.Interactivity;
using CookBook.ViewModels.Timers;

namespace CookBook.Views;

public partial class TimersView : UserControl
{
    private readonly TimersViewModel _vm;

    public TimersView()
    {
        DataContext = _vm = new TimersViewModel();
        InitializeComponent();
    }

    public TimersView(TimersViewModel vm)
    {
        DataContext = _vm = vm;
        InitializeComponent();
    }
}