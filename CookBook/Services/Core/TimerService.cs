using Avalonia.Threading;
using CookBook.Models;
using CookBook.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace CookBook.Services.Core;
public class TimerService : ITimerService
{
    private List<Action> _actions = [];
    private List<CookingTimer> _timers = [];
    private DispatcherTimer _mainTimer;
    public TimerService()
    {
        _mainTimer = new DispatcherTimer();
        _mainTimer.Interval = TimeSpan.FromSeconds(1);
        _mainTimer.Tick += Update;
    }

    public void AddEvent(Action action)
    {
        _actions.Add(action);
    }

    public void RemoveEvent(Action action)
    {
        _actions.Remove(action);
    }

    public CookingTimer AddTimer(TimeSpan time)
    {
        return AddTimer(new CookingTimer(time));
    }

    public CookingTimer AddTimer(CookingTimer timer)
    {
        _timers.Add(timer);
        timer.Start();
        _mainTimer.Start();
        return timer;
    }

    public List<CookingTimer> GetTimers()
    {
        return _timers;
    }

    public void RemoveTimer(CookingTimer timer)
    {
        _timers.Remove(timer);
    }

    private void Update(object? sender, EventArgs e)
    {
        foreach (var timer in _timers)
        {
            timer.OnTick();
        }

        foreach (var action in _actions)
        {
            action();
        }

        if (_timers.Count <= 0)
        {
            _mainTimer.Stop();
        }
    }
}

