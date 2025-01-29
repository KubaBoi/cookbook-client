using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Views;

namespace CookBook.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly RecipeDetailView _recipeDetailView;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public MainViewModel()
    {

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public MainViewModel(
        RecipeDetailView recipeDetailView)
    {
        _recipeDetailView = recipeDetailView;

        CurrentView = _recipeDetailView;
    }

    public string Greeting => "Welcome to Avalonia!";

    private UserControl? _currentView;
    public UserControl? CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }
}
