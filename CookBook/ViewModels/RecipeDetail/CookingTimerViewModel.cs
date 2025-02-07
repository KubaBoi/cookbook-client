using Avalonia.Controls.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CookBook.ViewModels.RecipeDetail;
public partial class CookingTimerViewModel : ObservableObject
{
    public CookingTimerViewModel(TimeSpan test)
    {
        _timer = new CookingTimer(test);
        _elapsed = test;
        _start = test.Add(TimeSpan.FromSeconds(10));

        _elapsedText = FormatTime(_elapsed);
        _startText = FormatTime(_start);
    }

    public CookingTimerViewModel(CookingTimer timer)
    {
        _timer = timer;
        Update();
    }

    private CookingTimer _timer;

    [ObservableProperty]
    private TimeSpan _elapsed;

    [ObservableProperty]
    private TimeSpan _start;

    [ObservableProperty]
    private bool _isRunning;

    [ObservableProperty]
    private string _elapsedText;

    [ObservableProperty]
    private string _startText;

    public void Update()
    {
        Elapsed = _timer.ElapsedTime;
        Start = _timer.StartTime;
        IsRunning = _timer.IsRunning;

        ElapsedText = FormatTime(Elapsed);
        StartText = FormatTime(Start);
    }

    private string FormatTime(TimeSpan span)
    {
        return new StringBuilder()
            .Append(span.Hours > 0 ? span.Hours : "")
            .Append(span.Hours > 0 ? ':' : "")
            .Append(span.Minutes <= 9 ? "0" : "")
            .Append(span.Minutes)
            .Append(':')
            .Append(span.Seconds <= 9 ? "0" : "")
            .Append(span.Seconds)
            .ToString();
    }
}

