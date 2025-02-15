using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CookBook.Models.Settings;

/// <summary>
/// Class representing settings from json config file
/// </summary>
public class Settings
{
    [JsonPropertyName("saved_timers")]
    public List<SavedTimer> SavedTimers { get; set; } = [];
}

