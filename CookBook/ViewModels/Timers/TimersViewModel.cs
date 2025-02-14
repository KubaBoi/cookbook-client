using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Services.Abstractions;
using CookBook.ViewModels.RecipeDetail;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace CookBook.ViewModels.Timers;
public partial class TimersViewModel : ViewModelBase
{
    private readonly ITimerService _timeService;
    private readonly INavigationService _navigationService;

    public TimersViewModel()
    {
        InitSavedTimers();
    }

    public TimersViewModel(
        ITimerService timerService,
        INavigationService navigationService)
    {
        _timeService = timerService;
        _navigationService = navigationService;

        InitSavedTimers();
        InitCommands();
    }

    #region Properties

    [ObservableProperty]
    private List<CookingTimerViewModel>? _savedTimers;

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

    #endregion

    #region Command methods

    private void InitCommands()
    {
        GoBackCommand = new RelayCommand(GoBack);
        UpdateHoursCommand = new RelayCommand<string?>(UpdateHours);
        UpdateMinutesCommand = new RelayCommand<string?>(UpdateMinutes);
        UpdateSecondsCommand = new RelayCommand<string?>(UpdateSeconds);
        StartTimerCommand = new RelayCommand(StartTimer);
    }

    private void GoBack()
    {
        _navigationService.Navigate(Services.Core.NavigationPath.RecipeDetail);
    }

    private void UpdateHours(string? strVal)
    {
        Debug.Assert(strVal is not null);

        // tohle je debilni, ale lepsi nez kvuli tomu vytvaret novy konvertor
        int value = int.Parse(strVal);
        _hours += value;
        if (_hours < 0)
        {
            _hours = 0;
        }
        HoursText = FormatNumber(_hours);

        IsHoursDecEnabled = _hours > 0;
        UpdateStartButtonEnabled();
    }

    private void UpdateMinutes(string? strVal)
    {
        Debug.Assert(strVal is not null);

        int value = int.Parse(strVal);
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

    private void UpdateSeconds(string? strVal)
    {
        Debug.Assert(strVal is not null);

        int value = int.Parse(strVal);
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

    #endregion

    #region Private methods

    private void InitSavedTimers()
    {
        SavedTimers = new List<CookingTimerViewModel>()
        {
            new CookingTimerViewModel(TimeSpan.FromMinutes(1)),
            new CookingTimerViewModel(TimeSpan.FromMinutes(5)),
            new CookingTimerViewModel(TimeSpan.FromMinutes(10)),
            new CookingTimerViewModel(TimeSpan.FromMinutes(15)),
            new CookingTimerViewModel(TimeSpan.FromHours(1))
        };
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

