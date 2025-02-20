using CookBook.Models.Settings;
using System.Collections.Generic;

namespace CookBook.Services.Abstractions;

public interface ISettings
{
    List<SavedTimer> SavedTimers { get; set; }
    int TimerAdditionSeconds { get; set; }
}

