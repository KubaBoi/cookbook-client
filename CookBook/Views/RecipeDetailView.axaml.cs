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
}