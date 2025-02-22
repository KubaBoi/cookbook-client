using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Models;
using CookBook.Services.Abstractions;
using CookBook.Services.Core;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
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
            new RecipeInfoViewModel("Nejaka pochutina", "Velmi narocne", "30 hodin", 4, "pekace", true),
            new RecipeInfoViewModel("1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9 1 3 5 7 9",
                                        "Velmi nenarocne", "3 hodiny", 5, "taliru", false),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", true),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", false),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", true),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", false),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", true),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", false),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", true),
            new RecipeInfoViewModel("Nejaka pochutina dva", "Velmi nenarocne", "3 hodiny", 5, "taliru", false)
        };

        _isDialogVisible = true;
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
    private ObservableCollection<RecipeInfoViewModel>? _recipes;

    [ObservableProperty]
    private bool _isDialogVisible = false;

    #endregion

    #region Commands

    [ObservableProperty]
    private ICommand? _goBackCommand;

    [ObservableProperty]
    private ICommand? _selectRecipeCommand;

    [ObservableProperty]
    private ICommand? _addRecipeCommand;

    [ObservableProperty]
    private ICommand? _updateRecipesCommand;

    #endregion

    #region Command methods

    private void InitCommands()
    {
        GoBackCommand = new RelayCommand(GoBack);
        SelectRecipeCommand = new RelayCommand<RecipeInfoViewModel?>(SelectRecipe);
        AddRecipeCommand = new AsyncRelayCommand(AddRecipeAsync);
        UpdateRecipesCommand = new AsyncRelayCommand(UpdateRecipesAsync);
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

    private async Task AddRecipeAsync()
    {
        IsDialogVisible = !IsDialogVisible;
    }

    private async Task UpdateRecipesAsync()
    {
        await _recipeService.UpdateRecipesFromServerAsync();
        LoadRecipes();
    }

    #endregion

    #region Public methods

    public void Init()
    {

    }

    public void Loaded()
    {
        LoadRecipes();
    }

    #endregion

    #region Private methods

    private void LoadRecipes()
    {
        Recipes = new ObservableCollection<RecipeInfoViewModel>();
        var loadedRecipes = _recipeService.ReadAllRecipes();
        for (int i = 0; i < loadedRecipes.Count; i++)
        {
            var recipe = loadedRecipes[i];
            Recipes.Add(new RecipeInfoViewModel(recipe, i % 2 == 0));
        }
    }

    #endregion
}

