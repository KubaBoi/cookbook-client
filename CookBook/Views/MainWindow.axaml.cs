using Avalonia.Controls;
using CookBook.ViewModels;

namespace CookBook.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new MainViewModel();
        InitializeComponent();
    }

    public MainWindow(MainViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
