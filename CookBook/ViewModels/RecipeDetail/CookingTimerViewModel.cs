using Avalonia.Controls.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CookBook.ViewModels.RecipeDetail;
public partial class CookingTimerViewModel : ObservableObject
{
    private readonly int ELEMENT_WIDTH = 242;

    public CookingTimerViewModel(TimeSpan stat, bool isTesting = false)
    {
        _timer = new CookingTimer(stat);
        _elapsed = stat;
        _start = stat.Add(TimeSpan.FromSeconds(isTesting ? 10 : 0));

        Recalculate();
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
    private bool _isDone;

    [ObservableProperty]
    private string? _elapsedText;

    [ObservableProperty]
    private string? _startText;

    [ObservableProperty]
    private int _width;

    [MemberNotNull(nameof(Elapsed),
                   nameof(Start),
                   nameof(Width))]
    public void Update()
    {
        Elapsed = _timer.ElapsedTime;
        Start = _timer.StartTime;
        IsRunning = _timer.IsRunning;

        Recalculate();

        ElapsedText = FormatTime(Elapsed);
        StartText = FormatTime(Start);
    }

    public void Pause()
    {
        IsRunning = !IsRunning;
    }

    private void Recalculate()
    {
        IsDone = Elapsed <= TimeSpan.Zero;
        if (IsDone) Width = ELEMENT_WIDTH;
        else Width = (int)(Elapsed / Start * ELEMENT_WIDTH);
    }

    private string FormatTime(TimeSpan span)
    {
        var spanCopy = TimeSpan.FromSeconds(span.TotalSeconds);
        bool isMinus = spanCopy <= TimeSpan.Zero;
        if (isMinus) spanCopy *= -1;

        return new StringBuilder()
            .Append(isMinus ? "-" : "")
            .Append(spanCopy.Hours > 0 ? spanCopy.Hours : "")
            .Append(spanCopy.Hours > 0 ? ':' : "")
            .Append(spanCopy.Minutes <= 9 ? "0" : "")
            .Append(spanCopy.Minutes)
            .Append(':')
            .Append(spanCopy.Seconds <= 9 ? "0" : "")
            .Append(spanCopy.Seconds)
            .ToString();
    }
}

