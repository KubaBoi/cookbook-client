using Avalonia.Controls;
using CookBook.ViewModels;

namespace CookBook.Views;

public partial class MainView : UserControl
{
    private readonly MainViewModel _vm;

    public MainView()
    {
        DataContext = _vm = new MainViewModel();
        InitializeComponent();
    }

    public MainView(MainViewModel vm)
    {
        DataContext = _vm = vm;
        InitializeComponent();
    }
}
