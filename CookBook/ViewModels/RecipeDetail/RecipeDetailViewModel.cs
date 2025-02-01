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
        _portionCounter = 4;
    }

    public RecipeDetailViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;

        _recipe = _recipeService.SelectedRecipe;

        InitCommands();
    }

    #region Properties

    [ObservableProperty]
    public Recipe? _recipe;

    [ObservableProperty]
    public string? _mainTitle;

    [ObservableProperty]
    public int? _portionCounter = 2;

    [ObservableProperty]
    public bool _isMinusPortionButtonEnabled = true;

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
    }

    private void PlusPortion()
    {
        PortionCounter++;
        IsMinusPortionButtonEnabled = true;
    }

    #endregion

    #region Public methods

    #endregion
}

