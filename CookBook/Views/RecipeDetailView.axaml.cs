using Avalonia.Controls;
using CookBook.ViewModels.RecipeDetail;
using System.Threading.Tasks;

namespace CookBook.Views;
public partial class RecipeDetailView : UserControl
{
    private readonly RecipeDetailViewModel _vm;

    public RecipeDetailView()
    {
        DataContext = _vm = new RecipeDetailViewModel();
        InitializeComponent();
    }

    public RecipeDetailView(RecipeDetailViewModel vm)
    {
        DataContext = _vm = vm;
        InitializeComponent();
        this.Initialized += RevipeDetailView_Initialized;
        this.Unloaded += RecipeDetailView_Unloaded;
    }

    private void RevipeDetailView_Initialized(object? sender, System.EventArgs e)
    {
        _vm.Init();
    }

    private void RecipeDetailView_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _vm.Dispose();
    }

    private void Border_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
    {
    }

    private void Binding_1(object? sender, Avalonia.Input.KeyEventArgs e)
    {
    }

    private void Border_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
    }

    private void Border_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
    {
    }

    private void Border_PointerPressed_1(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
    }
}