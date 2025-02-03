using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Models;
using CookBook.Services.Abstractions;
using System.Collections.Generic;
using System.Diagnostics;
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
        _portionCounter = 4;

        _ingredients = new List<IngredientViewModel>
        {
            new IngredientViewModel(5, "krát", "párek", _portionCounter),
            new IngredientViewModel(4, "ks", "cibule", _portionCounter),
            new IngredientViewModel(5, "lžic", "oleje", _portionCounter),
            new IngredientViewModel(700, "g", "rybízu", _portionCounter),
            new IngredientViewModel("Na drobenku"),
            new IngredientViewModel(4, "PL", "Krupicový cukr", _portionCounter),
            new IngredientViewModel(1, "bal", "Vanilkový cukraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", _portionCounter),
        };
    }

    public RecipeDetailViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;

        _recipe = _recipeService.SelectedRecipe;

        InitCommands();

        _portionCounter = 4;

        _ingredients = new List<IngredientViewModel>
        {
            new IngredientViewModel(5, "krát", "párek", _portionCounter),
            new IngredientViewModel(4, "ks", "cibule", _portionCounter),
            new IngredientViewModel(5, "lžic", "oleje", _portionCounter),
            new IngredientViewModel(700, "g", "rybízu", _portionCounter),
            new IngredientViewModel("Na drobenku"),
            new IngredientViewModel(4, "PL", "Krupicový cukr", _portionCounter),
            new IngredientViewModel(1, "bal", "Vanilkový cukraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", _portionCounter),
        };
    }

    #region Properties

    [ObservableProperty]
    private Recipe? _recipe;

    [ObservableProperty]
    private string? _mainTitle;

    [ObservableProperty]
    private int? _portionCounter;

    [ObservableProperty]
    private bool _isMinusPortionButtonEnabled = true;

    [ObservableProperty]
    private List<IngredientViewModel> _ingredients;

    #endregion

    #region Commands

    [ObservableProperty]
    public ICommand _minusPortionCommand;

    [ObservableProperty]
    public ICommand _plusPortionCommand;

    #endregion

    #region Command methods

    [MemberNotNull(
        nameof(MinusPortionCommand),
        nameof(PlusPortionCommand))]
    private void InitCommands()
    {
        MinusPortionCommand = new RelayCommand(MinusPortion);
        PlusPortionCommand = new RelayCommand(PlusPortion);
    }

    private void MinusPortion()
    {
        if (PortionCounter > 1)
        {
            PortionCounter--;
        }
        
        if (PortionCounter <= 1)
        {
            IsMinusPortionButtonEnabled = false;
        }

        RecalculateIngredientCounts();
    }

    private void PlusPortion()
    {
        PortionCounter++;
        IsMinusPortionButtonEnabled = true;
        RecalculateIngredientCounts();
    }

    #endregion

    #region Public methods

    #endregion

    #region Private methods

    private void RecalculateIngredientCounts()
    {
        foreach (var ing in Ingredients)
        {
            ing.Count = ing.NormalCount * PortionCounter;
        }
    }

    #endregion
}

