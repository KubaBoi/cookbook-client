using CookBook.Services.Abstractions;

namespace CookBook.ViewModels.Recipes;
public class RecipesViewModel : ViewModelBase
{
    private readonly IRecipeService _recipeService;
    private readonly ISettings _settings;
    private readonly INavigationService _navigationService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public RecipesViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {

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

    }

    #endregion

    #region Private methods

    #endregion
}

