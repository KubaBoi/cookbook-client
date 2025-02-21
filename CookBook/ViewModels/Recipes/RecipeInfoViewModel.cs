using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Models;
using System.Diagnostics;

namespace CookBook.ViewModels.Recipes;
public partial class RecipeInfoViewModel : ObservableObject
{
    public RecipeInfoViewModel(Recipe recipe, bool isEven)
    {
        Debug.Assert(recipe.Header is not null);

        Recipe = recipe;
        Name = recipe.Name ?? "Missing Name";
        Difficulty = recipe.Header.Difficulty ?? "Missing Difficulty";
        Duration = recipe.Header.Duration ?? "Missing Duration";
        Portions = recipe.Header.Portions;
        PortionUnit = recipe.Header.PortionUnit ?? "Missing PortionUnit";
        IsEven = isEven;

        SetTitleFontSize();
    }

    public RecipeInfoViewModel(string name, string difficulty, string duration, int portions, string portionUnit, bool isEven)
    {
        Name = name;
        Difficulty = difficulty;
        Duration = duration;
        Portions = portions;
        PortionUnit = portionUnit;
        IsEven = isEven;

        SetTitleFontSize();
    }

    public Recipe? Recipe { get; set; }

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _difficulty;

    [ObservableProperty]
    private string _duration;

    [ObservableProperty]
    private int _portions;

    [ObservableProperty]
    private string _portionUnit;

    [ObservableProperty]
    private bool _isEven;

    [ObservableProperty]
    private double _titleFontSize;

    private void SetTitleFontSize()
    {
        TitleFontSize = 24;
        if (Name.Length > 180)
            TitleFontSize = 18;
    }
}

