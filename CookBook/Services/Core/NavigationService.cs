using CookBook.Services.Abstractions;
using CookBook.ViewModels;

namespace CookBook.Services.Core;
public class NavigationService : INavigationService
{
    private readonly MainViewModel _mainViewModel;

    public NavigationService(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    public void Navigate(NavigationPath path)
    {

    }
}

public enum NavigationPath
{
    RecipeDetail,
    RecipeSelection,
    Timers
}

