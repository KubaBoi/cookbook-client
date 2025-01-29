using Avalonia.Controls;
using CookBook.ViewModels;

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
    }
}