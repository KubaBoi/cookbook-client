using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Services.Abstractions;
using CookBook.ViewModels.RecipeDetail;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace CookBook.ViewModels.Timers;
public partial class TimersViewModel : ViewModelBase
{
    private readonly ITimerService _timeService;
    private readonly INavigationService _navigationService;
    private readonly ISettings _settings;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public TimersViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        InitSavedTimers();
    }

    public TimersViewModel(
        ITimerService timerService,
        INavigationService navigationService,
        ISettings settings)
    {
        _timeService = timerService;
        _navigationService = navigationService;
        _settings = settings;

        InitSavedTimers();
        InitCommands();
    }

    #region Properties

    [ObservableProperty]
    private ObservableCollection<CookingTimerViewModel>? _savedTimers;

    [ObservableProperty]
    private string? _hoursText = "00";
    private int _hours = 0;

    [ObservableProperty]
    private bool _isHoursDecEnabled = false;

    [ObservableProperty]
    private string? _minutesText = "00";
    private int _minutes = 0;

    [ObservableProperty]
    private string? _secondsText = "00";
    private int _seconds = 0;

    [ObservableProperty]
    private bool _isStartButtonEnabled;

    #endregion

    #region Commands

    [ObservableProperty]
    private ICommand? _GoBackCommand;

    [ObservableProperty]
    private ICommand? _updateHoursCommand;

    [ObservableProperty]
    private ICommand? _updateMinutesCommand;

    [ObservableProperty]
    private ICommand? _updateSecondsCommand;

    [ObservableProperty]
    private ICommand? _startTimerCommand;

    [ObservableProperty]
    private ICommand? _loadSavedTimerCommand;

    #endregion

    #region Command methods

    private void InitCommands()
    {
        GoBackCommand = new RelayCommand(GoBack);
        UpdateHoursCommand = new RelayCommand<string?>(UpdateHours);
        UpdateMinutesCommand = new RelayCommand<string?>(UpdateMinutes);
        UpdateSecondsCommand = new RelayCommand<string?>(UpdateSeconds);
        StartTimerCommand = new RelayCommand(StartTimer);
        LoadSavedTimerCommand = new RelayCommand<CookingTimerViewModel?>(LoadSavedTimer);
    }

    private void GoBack()
    {
        _navigationService.Navigate(Services.Core.NavigationPath.RecipeDetail);
    }

    private void UpdateHours(string? strVal = null)
    {
        // tohle je debilni, ale lepsi nez kvuli tomu vytvaret novy konvertor
        int value = 0;
        if (strVal is not null)
            value = int.Parse(strVal);

        _hours += value;
        if (_hours < 0)
        {
            _hours = 0;
        }
        HoursText = FormatNumber(_hours);

        IsHoursDecEnabled = _hours > 0;
        UpdateStartButtonEnabled();
    }

    private void UpdateMinutes(string? strVal = null)
    {
        int value = 0;
        if (strVal is not null)
            value = int.Parse(strVal);

        _minutes += value;
        if (_minutes < 0)
        {
            _minutes += 60;
        }
        if (_minutes >= 60)
        {
            _minutes -= 60;
        }

        MinutesText = FormatNumber(_minutes);
        UpdateStartButtonEnabled();
    }

    private void UpdateSeconds(string? strVal = null)
    {
        int value = 0;
        if (strVal is not null)
            value = int.Parse(strVal);

        _seconds += value;
        if (_seconds < 0)
        {
            _seconds += 60;
        }
        if (_seconds >= 60)
        {
            _seconds -= 60;
        }

        SecondsText = FormatNumber(_seconds);
        UpdateStartButtonEnabled();
    }

    private void StartTimer()
    {
        _timeService.AddTimer(new TimeSpan(_hours, _minutes, _seconds));
        GoBack();
    }

    private void LoadSavedTimer(CookingTimerViewModel? timer)
    {
        Debug.Assert(timer is not null);

        _hours = timer.Start.Hours;
        _minutes = timer.Start.Minutes;
        _seconds = timer.Start.Seconds;

        UpdateHours();
        UpdateMinutes();
        UpdateSeconds();
    }

    #endregion

    #region Private methods

    private void InitSavedTimers()
    {
        SavedTimers = new ObservableCollection<CookingTimerViewModel>();
        foreach (var savedTimer in _settings.SavedTimers)
        {
            int seconds = (savedTimer.Hours * 60 * 60) + (savedTimer.Minutes * 60) + savedTimer.Seconds;
            SavedTimers.Add(new CookingTimerViewModel(TimeSpan.FromSeconds(seconds)));
        }
    }

    private void UpdateStartButtonEnabled()
    {
        IsStartButtonEnabled = (_hours + _minutes + _seconds > 0);
    }

    private string FormatNumber(int value)
    {
        return value > 9 ? value.ToString() : "0" + value.ToString();
    }

    #endregion
}

