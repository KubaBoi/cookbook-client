using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookBook.Models;
public class Ingredient
{
    public Ingredient() { }

    public Ingredient(string? name)
    {
        Name = name;
        IsTitle = true;
    }

    public Ingredient(string? name, double? amount, string? unit)
    {
        Name = name;
        Amount = amount;
        Unit = unit;
    }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }
    
    [JsonPropertyName("amount_str")]
    public string? AmountText { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("is_title")]
    public bool IsTitle { get; set; }
}

