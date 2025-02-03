﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Models;
using CookBook.Services.Abstractions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace CookBook.ViewModels.RecipeDetail;
public partial class RecipeDetailViewModel : ViewModelBase
{
    private readonly IRecipeService _recipeService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public RecipeDetailViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        _mainTitle = "Koláč s čokoládou";
        _portionCounter = 4;

        _recipe = new Recipe()
        {
            Name = "Koláč s čokoládou",
            Source = "https://source.com",
            Header = new Header()
            {
                Duration = "90 minut",
                Difficulty = "Snadná",
                Portions = 4,
                PortionUnit = "porce"
            },
            Steps = new List<string>
            {
                "Troubu předehřejte na 180 °C. Kulatou formu o průměru asi 28 cm nebo plech s vyššími okraji vymažte máslem a vysypte hrubou moukou.",
                "Suroviny na drobenku propracujte prsty a hotovou drobenku prozatím uložte do lednice.",
                "V míse utřete vejce s cukrem do světlé pěny, vmíchejte smetanu, prosátou mouku smíchanou s kypřicím práškem do pečiva a dobře promíchejte.",
                "Těsto opatrně roztáhněte pomocí stěrky po celé ploše formy, poklaďte je rovnoměrně ovocem – banánem a rybízem – a nakonec na ně rozprostřete drobenku.",
                "Vložte do trouby a pečte 25–30 minut, až drobenka zezlátne a bude křupavá (pokud použijete ovoce s větším obsahem vody, pečte koláč o 5 minut déle).",
                "TIPY A TRIKY\r\nK některým druhům ovoce, například jablkům nebo hruškám, ladí dobře skořice, k jiným (rybízu nebo višním) je zase zajímavá vanilka – nahraďte podle použitého ovoce adekvátní část krupicového cukru v drobence vanilkovým nebo skořicovým cukrem. Pokud použijete hodně kyselé ovoce, můžete přidat do drobenky o lžíci cukru a kousek másla víc."
            },
            Ingredients = new List<Ingredient>
            {
                new Ingredient("párek", "5 krát"),
                new Ingredient("cibule", "4 ks"),
                new Ingredient("oleje", "5 lžic"),
                new Ingredient("rybízu", "700 g"),
                new Ingredient("Na drobenku", null),
                new Ingredient("Krupicový cukr", "5 krát"),
                new Ingredient("párek", "5 krát"),
                new Ingredient("Vanilkový cukraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "5 krát"),
            }
        };


        _ingredients = new List<IngredientViewModel>
        {
            new IngredientViewModel(5, "krát", "párek", _portionCounter),
            new IngredientViewModel(4, "ks", "cibule", _portionCounter),
            new IngredientViewModel(5, "lžic", "oleje", _portionCounter),
            new IngredientViewModel(700, "g", "rybízu", _portionCounter),
            new IngredientViewModel("Na drobenku"),
            new IngredientViewModel(4, "PL", "Krupicový cukr", _portionCounter),
            new IngredientViewModel(1, "bal", "Vanilkový cukraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", _portionCounter),
        };
    }

    public RecipeDetailViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;

        _recipe = _recipeService.SelectedRecipe;

        InitCommands();

        _portionCounter = 4;

        _ingredients = new List<IngredientViewModel>
        {
            new IngredientViewModel(5, "krát", "párek", _portionCounter),
            new IngredientViewModel(4, "ks", "cibule", _portionCounter),
            new IngredientViewModel(5, "lžic", "oleje", _portionCounter),
            new IngredientViewModel(700, "g", "rybízu", _portionCounter),
            new IngredientViewModel("Na drobenku"),
            new IngredientViewModel(4, "PL", "Krupicový cukr", _portionCounter),
            new IngredientViewModel(1, "bal", "Vanilkový cukraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", _portionCounter),
        };
    }

    #region Properties

    [ObservableProperty]
    private Recipe? _recipe;

    [ObservableProperty]
    private string? _mainTitle;

    [ObservableProperty]
    private int? _portionCounter;

    [ObservableProperty]
    private bool _isMinusPortionButtonEnabled = true;

    [ObservableProperty]
    private List<IngredientViewModel> _ingredients;

    #endregion

    #region Commands

    [ObservableProperty]
    public ICommand _minusPortionCommand;

    [ObservableProperty]
    public ICommand _plusPortionCommand;

    #endregion

    #region Command methods

    [MemberNotNull(
        nameof(MinusPortionCommand),
        nameof(PlusPortionCommand))]
    private void InitCommands()
    {
        MinusPortionCommand = new RelayCommand(MinusPortion);
        PlusPortionCommand = new RelayCommand(PlusPortion);
    }

    private void MinusPortion()
    {
        if (PortionCounter > 1)
        {
            PortionCounter--;
        }
        
        if (PortionCounter <= 1)
        {
            IsMinusPortionButtonEnabled = false;
        }

        RecalculateIngredientCounts();
    }

    private void PlusPortion()
    {
        PortionCounter++;
        IsMinusPortionButtonEnabled = true;
        RecalculateIngredientCounts();
    }

    #endregion

    #region Public methods

    #endregion

    #region Private methods

    private void RecalculateIngredientCounts()
    {
        foreach (var ing in Ingredients)
        {
            ing.Count = ing.NormalCount * PortionCounter;
        }
    }

    #endregion
}

