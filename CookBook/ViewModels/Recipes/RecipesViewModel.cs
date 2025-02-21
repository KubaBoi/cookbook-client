using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Models;
using CookBook.Services.Abstractions;
using CookBook.Services.Core;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace CookBook.ViewModels.Recipes;
public partial class RecipesViewModel : ViewModelBase
{
    private readonly IRecipeService _recipeService;
    private readonly ISettings _settings;
    private readonly INavigationService _navigationService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public RecipesViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        Recipes = new ObservableCollection<RecipeInfoViewModel>()
        {
            new RecipeInfoViewModel("Nejaka pochutina", "Velmi narocne", "30 hodin", 4, "pekace"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru"),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru")
        };
    }

    public RecipesViewModel(
        IRecipeService recipeService,
        ISettings settings,
        INavigationService navigationService)
    {
        _recipeService = recipeService;
        _settings = settings;
        _navigationService = navigationService;

        InitCommands();
    }

    #region Properties

    [ObservableProperty]
    private ObservableCollection<RecipeInfoViewModel> _recipes;

    #endregion

    #region Commands

    [ObservableProperty]
    private ICommand? _goBackCommand;

    [ObservableProperty]
    private ICommand? _selectRecipeCommand;

    #endregion

    #region Command methods

    private void InitCommands()
    {
        GoBackCommand = new RelayCommand(GoBack);
        SelectRecipeCommand = new RelayCommand<RecipeInfoViewModel?>(SelectRecipe);
    }

    private void GoBack()
    {
        _navigationService.Navigate(NavigationPath.RecipeDetail);
    }

    private void SelectRecipe(RecipeInfoViewModel? recipeInfo)
    {
        Debug.Assert(recipeInfo is not null);

        _recipeService.SelectedRecipe = recipeInfo.Recipe;
        GoBack();
    }

    #endregion

    #region Public methods

    public void Init()
    {

    }

    public void Loaded()
    {
        Recipes = new ObservableCollection<RecipeInfoViewModel>();
        foreach (var recipe in _recipeService.ReadAllRecipes())
        {
            Recipes.Add(new RecipeInfoViewModel(recipe));
        }
    }

    #endregion

    #region Private methods

    #endregion
}

