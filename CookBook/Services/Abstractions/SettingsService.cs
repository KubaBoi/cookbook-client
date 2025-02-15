using CookBook.Models.Settings;
using System.Collections.Generic;

namespace CookBook.Services.Abstractions;
public interface SettingsService
{
    void LoadSettings();

    Settings Settings { get; }

    List<SavedTimer> SavedTimers { get; }
}

