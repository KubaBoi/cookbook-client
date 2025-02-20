using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Services.Abstractions;
using CookBook.Services.Core;
using CookBook.Views;

namespace CookBook.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    private readonly RecipeDetailView _recipeDetailView;
    private readonly TimersView _timersView;
    private readonly RecipesView _recipesView;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public MainViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        _currentView = new RecipeDetailView();
    }

    public MainViewModel(
        INavigationService navigationService,
        RecipeDetailView recipeDetailView,
        TimersView timersView,
        RecipesView recipesView)
    {
        _navigationService = navigationService;
        _recipeDetailView = recipeDetailView;
        _timersView = timersView;
        _recipesView = recipesView;

        _navigationService.SetNavigationChangeHandler(ChangeView);

        //ChangeView(NavigationPath.Timers);
        ChangeView(NavigationPath.RecipeSelection);
        //ChangeView();
    }

    [ObservableProperty]
    private UserControl? _currentView;

    public void ChangeView(NavigationPath path = NavigationPath.RecipeDetail)
    {
        switch (path)
        {
            case NavigationPath.RecipeDetail:
                CurrentView = _recipeDetailView;
                break;
            case NavigationPath.Timers:
                CurrentView = _timersView;
                break;
            case NavigationPath.RecipeSelection:
                CurrentView = _recipesView;
                break;
        }
    }
}
