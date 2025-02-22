using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Models;
using CookBook.Services.Abstractions;
using CookBook.Services.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace CookBook.ViewModels.RecipeDetail;
public partial class RecipeDetailViewModel : ViewModelBase
{
    private readonly IRecipeService _recipeService;
    private readonly ITimerService _timerService;
    private readonly ISettings _settings;
    private readonly INavigationService _navigationService;

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
                new Ingredient("párek", 5, "krát"),
                new Ingredient("cibule", 4, "ks"),
                new Ingredient("oleje", 5, "lžic"),
                new Ingredient("rybízu", 700, "g"),
                new Ingredient("Na drobenku"),
                new Ingredient("Krupicový cukr", 5, "krát"),
                new Ingredient("párek", 5, "krát"),
                new Ingredient("Vanilkový cukraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 5, "krát"),
            }
        };

        InitIngredients();
        InitSteps();

        Timers = new ObservableCollection<CookingTimerViewModel>()
        {
            new CookingTimerViewModel(TimeSpan.FromSeconds(5), true),
            new CookingTimerViewModel(TimeSpan.FromSeconds(-5), true),
            new CookingTimerViewModel(TimeSpan.FromSeconds(1000), true),
            new CookingTimerViewModel(TimeSpan.FromSeconds(150), true),
            new CookingTimerViewModel(TimeSpan.FromSeconds(20), true)
        };
    }

    public RecipeDetailViewModel(
        IRecipeService recipeService,
        ITimerService timerService,
        ISettings settings,
        INavigationService navigationService)
    {
        _recipeService = recipeService;
        _timerService = timerService;
        _settings = settings;
        _navigationService = navigationService;

        InitCommands();
    }

    #region Properties

    [ObservableProperty]
    private Recipe? _recipe;

    [ObservableProperty]
    private string? _mainTitle;

    [ObservableProperty]
    private double _mainTitleFontSize = 40;

    [ObservableProperty]
    private int? _portionCounter;

    [ObservableProperty]
    private bool _isMinusPortionButtonEnabled = true;

    [ObservableProperty]
    private ObservableCollection<StepViewModel>? _steps;

    [ObservableProperty]
    private ObservableCollection<IngredientViewModel>? _ingredients;

    [ObservableProperty]
    private ObservableCollection<CookingTimerViewModel>? _timers;

    #endregion

    #region Commands

    [ObservableProperty]
    private ICommand? _minusPortionCommand;

    [ObservableProperty]
    private ICommand? _plusPortionCommand;

    [ObservableProperty]
    private ICommand? _downTimerCommand;

    [ObservableProperty]
    private ICommand? _upTimerCommand;

    [ObservableProperty]
    private ICommand? _pauseTimerCommand;

    [ObservableProperty]
    private ICommand? _deleteTimerCommand;

    [ObservableProperty]
    private ICommand? _goToTimersViewCommand;

    [ObservableProperty]
    private ICommand? _goToRecipesViewCommand;

    #endregion

    #region Command methods

    private void InitCommands()
    {
        MinusPortionCommand = new RelayCommand(MinusPortion);
        PlusPortionCommand = new RelayCommand(PlusPortion);
        DownTimerCommand = new RelayCommand<CookingTimerViewModel?>(DownTimer);
        UpTimerCommand = new RelayCommand<CookingTimerViewModel?>(UpTimer);
        PauseTimerCommand = new RelayCommand<CookingTimerViewModel?>(PauseTimer);
        DeleteTimerCommand = new RelayCommand<CookingTimerViewModel?>(DeleteTimer);
        GoToTimersViewCommand = new RelayCommand(GoToTimersView);
        GoToRecipesViewCommand = new RelayCommand(GoToRecipesView);
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

    private void DownTimer(CookingTimerViewModel? timer)
    {
        if (timer is null) return;

        timer.Sub(TimeSpan.FromSeconds(_settings.TimerAdditionSeconds));
        timer.Update();
    }

    private void UpTimer(CookingTimerViewModel? timer)
    {
        if (timer is null) return;

        timer.Add(TimeSpan.FromSeconds(_settings.TimerAdditionSeconds));
        timer.Update();
    }

    private void PauseTimer(CookingTimerViewModel? timer)
    {
        if (timer is null) return;

        timer.Pause();
    }

    private void DeleteTimer(CookingTimerViewModel? timer)
    {
        Debug.Assert(Timers is not null);
        if (timer is null) return;

        _timerService.RemoveTimer(timer._timer);
        Timers.Remove(timer);
    }

    private void GoToTimersView()
    {
        _navigationService.Navigate(NavigationPath.Timers);
    }

    private void GoToRecipesView()
    {
        _navigationService.Navigate(NavigationPath.RecipeSelection);
    }

    #endregion

    #region Public methods

    public void Init()
    {
        _timerService.AddEvent(UpdateTimers);
    }

    public void Loaded()
    {
        Recipe = _recipeService.SelectedRecipe;
        if (Recipe is not null)
        {
            MainTitle = Recipe.Name;
            MainTitleFontSize = 40;
            if (MainTitle?.Length > 40)
            {
                MainTitleFontSize = 30;
                if (MainTitle?.Length > 130)
                    MainTitleFontSize = 14;
            }

            PortionCounter = Recipe.Header?.Portions;
            InitSteps();
            InitIngredients();
        }
        InitTimers();
    }

    #endregion

    #region Private methods

    private void RecalculateIngredientCounts()
    {
        if (Ingredients is null)
            return;
        foreach (var ing in Ingredients)
        {
            ing.Count = ing.NormalCount * PortionCounter;
        }
    }

    private void InitSteps()
    {
        Debug.Assert(Recipe is not null);

        Steps = new ObservableCollection<StepViewModel>();
        for (int i = 0; i < Recipe.Steps.Count; i++)
        {
            Steps.Add(new(i + 1, Recipe.Steps[i]));
        }
    }

    private void InitIngredients()
    {
        Debug.Assert(Recipe is not null);

        Ingredients = new ObservableCollection<IngredientViewModel>();
        foreach (var ing in Recipe.Ingredients)
        {
            if (ing.Name is null) continue;
            if (ing.IsTitle)
            {
                // title
                Ingredients.Add(new IngredientViewModel(ing.Name));
            }
            else
            {
                // ingredient
                if (ing.Amount is not null)
                {
                    Ingredients.Add(new IngredientViewModel(ing.Amount, ing.Unit, ing.Name, PortionCounter));
                }
                else
                {
                    Ingredients.Add(new IngredientViewModel(ing.Name, ing.AmountText!));
                }
            }
        }
    }

    private void InitTimers()
    {
        Timers = new();
        foreach (var timer in _timerService.GetTimers())
        {
            Timers.Add(new CookingTimerViewModel(timer));
        }
    }

    private void UpdateTimers()
    {
        Debug.Assert(Timers is not null);
        foreach (var timer in Timers)
        {
            timer.Update();
        }
    }


    #endregion
}

