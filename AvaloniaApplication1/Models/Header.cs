using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookBook.Models;
public class Header
{
    /// <summary>
    /// Text description of time duration.
    /// </summary>
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }
    /// <summary>
    /// Text description of difficulty of recipe.
    /// </summary>
    [JsonPropertyName("difficulty")]
    public string? Difficulty {  get; set; }
    /// <summary>
    /// For how many portions is recipe prepared.
    /// </summary>
    [JsonPropertyName("portions")]
    public int Portions { get; set; }
    /// <summary>
    /// Unit for describtion of portions count. 
    /// (porce, plech, ...)
    /// </summary>
    [JsonPropertyName("portion_unit")]
    public string? PortionUnit { get; set; }
}

