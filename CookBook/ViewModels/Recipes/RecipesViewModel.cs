using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Models;
using CookBook.Services.Abstractions;
using System.Collections.ObjectModel;

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
    }

    #region Properties

    [ObservableProperty]
    private ObservableCollection<RecipeInfoViewModel> _recipes;

    #endregion

    #region Commands

    #endregion

    #region Command methods

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

