using CookBook.Models.Settings;
using System.Collections.Generic;

namespace CookBook.Services.Abstractions;

public interface ISettings
{
    Urls Urls { get; set; }
    int TimerAdditionSeconds { get; set; }
    List<SavedTimer> SavedTimers { get; set; }
}

