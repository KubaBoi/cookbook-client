using Avalonia.Controls;
using CookBook.ViewModels.Recipes;

namespace CookBook.Views;

public partial class RecipesView : UserControl
{
    private readonly RecipesViewModel _vm;

    public RecipesView()
    {
        DataContext = _vm = new RecipesViewModel();
        InitializeComponent();
    }

    public RecipesView(RecipesViewModel vm)
    {
        DataContext = _vm = vm;
        InitializeComponent();
        this.Initialized += RecipesView_Initialized;
        this.Loaded += RecipesView_Loaded;
    }

    private void RecipesView_Initialized(object? sender, System.EventArgs e)
    {
        _vm.Init();
    }

    private void RecipesView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _vm.Loaded();
    }
}