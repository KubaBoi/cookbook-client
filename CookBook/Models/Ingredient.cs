using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookBook.Models;
public class Ingredient
{
    /// <summary>
    /// Name of ingredient. (mrkev, vejce, ...)
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Text description of amount of ingredient with unit.
    /// </summary>
    public string? Amount { get; set; }
}

