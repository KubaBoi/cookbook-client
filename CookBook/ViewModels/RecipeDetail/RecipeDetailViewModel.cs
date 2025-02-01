using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Models;
using CookBook.Services.Abstractions;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace CookBook.ViewModels.RecipeDetail;
public partial class RecipeDetailViewModel : ViewModelBase
{
    private readonly IRecipeService _recipeService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public RecipeDetailViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        _mainTitle = "Koláč s čokoládou";
    }

    public RecipeDetailViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;

        _recipe = _recipeService.SelectedRecipe;

        InitCommands();
    }

    [ObservableProperty]
    public string? _mainTitle;

    [ObservableProperty]
    public Recipe? _recipe;

    #region Commands

    [ObservableProperty]
    public ICommand _minusPortionCommand;

    #endregion

    #region Command methods

    [MemberNotNull(nameof(MinusPortionCommand))]
    private void InitCommands()
    {
        MinusPortionCommand = new RelayCommand(MinusPortion);
    }

    private void MinusPortion()
    {
        string a = "";
    }

    #endregion

    #region Public methods

    #endregion
}

