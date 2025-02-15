using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CookBook.Models;
public class Recipe
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    /// <summary>
    /// Name of recipe.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    /// <summary>
    /// Text url of recipe source.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }
    /// <summary>
    /// Header of recipe.
    /// </summary>
    [JsonPropertyName("header")]
    public Header? Header { get; set; }
    /// <summary>
    /// Text steps of recipe.
    /// </summary>
    [JsonPropertyName("steps")]
    public List<string> Steps { get; set; } = [];
    /// <summary>
    /// Ingredients needed.
    /// </summary>
    [JsonPropertyName("ingredients")]
    public List<Ingredient> Ingredients { get; set; } = [];


}
