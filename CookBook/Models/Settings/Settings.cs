using CookBook.Services.Abstractions;
using System.Collections.Generic;

namespace CookBook.Models.Settings;

/// <summary>
/// Class representing settings from json config file
/// </summary>
public class Settings : ISettings
{
    public List<SavedTimer> SavedTimers { get; set; } = [];
    public int TimerAdditionSeconds { get; set; } = 5;
}

