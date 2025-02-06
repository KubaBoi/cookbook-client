using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.ViewModels.RecipeDetail;
public partial class IngredientViewModel : ObservableObject
{
    public IngredientViewModel(string name)
    {
        _name = name;
        _isTitle = true;
    }

    public IngredientViewModel(string name, string amountText)
    {
        _name = name;
        _unit = amountText;
    }

    public IngredientViewModel(double? count, string? unit, string name, int? defaultPortions)
    {
        _count = count;
        _unit = unit;
        _name = name;
        _normalCount = count / defaultPortions;
    }

    /// <summary>
    /// True if object is Title of ingredients section
    /// </summary>
    [ObservableProperty]
    private bool _isTitle;

    /// <summary>
    /// Actual count
    /// </summary>
    [ObservableProperty]
    private double? _count;

    [ObservableProperty]
    private string? _unit;

    [ObservableProperty]
    private string _name;

    /// <summary>
    /// Count if portions is 1
    /// </summary>
    [ObservableProperty]
    private double? _normalCount;

}

