using Avalonia.Controls;
using CookBook.ViewModels.Settings;

namespace CookBook.Views;
public partial class SettingsView : UserControl
{
    private readonly SettingsViewModel _vm;

    public SettingsView()
    {
        DataContext = _vm = new SettingsViewModel();
        InitializeComponent();
    }

    public SettingsView(SettingsViewModel vm)
    {
        DataContext = _vm = vm;
        InitializeComponent();
    }
}