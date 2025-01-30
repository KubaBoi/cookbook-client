using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Models;
using CookBook.Services.Abstractions;

namespace CookBook.ViewModels.RecipeDetail;
public partial class RecipeDetailViewModel : ViewModelBase
{
    private readonly IRecipeService _recipeService;

    public RecipeDetailViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;

        _recipe = _recipeService.SelectedRecipe;
        _text = "Koláč s čokoládou";
    }

    [ObservableProperty]
    public string _text;

    [ObservableProperty]
    public Recipe? _recipe;
}

