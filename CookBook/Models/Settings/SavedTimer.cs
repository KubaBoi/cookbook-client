using System.Text.Json.Serialization;

namespace CookBook.Models.Settings;

/// <summary>
/// Class representing timer saved in json config.
/// </summary>
public class SavedTimer
{

    [JsonPropertyName("hours")]
    public int Hours { get; set; }

    [JsonPropertyName("minutes")]
    public int Minutes { get; set; }

    [JsonPropertyName("seconds")]
    public int Seconds { get; set; }
}

