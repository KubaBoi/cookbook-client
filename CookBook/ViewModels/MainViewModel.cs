using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Services.Core;
using CookBook.ViewModels.Timers;
using CookBook.Views;

namespace CookBook.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly RecipeDetailView _recipeDetailView;
    private readonly TimersView _timersView;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public MainViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        _currentView = new RecipeDetailView();
    }

    public MainViewModel(
        RecipeDetailView recipeDetailView,
        TimersView timersView)
    {
        _recipeDetailView = recipeDetailView;
        _timersView = timersView;

        //ChangeView(NavigationPath.Timers);
        ChangeView();
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
        }
    }
}
