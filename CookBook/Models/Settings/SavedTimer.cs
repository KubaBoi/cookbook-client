using System.Text.Json.Serialization;

namespace CookBook.Models.Settings;

/// <summary>
/// Class representing timer saved in json config.
/// </summary>
public class SavedTimer
{
    public int Hours { get; set; }

    public int Minutes { get; set; }

    public int Seconds { get; set; }
}

