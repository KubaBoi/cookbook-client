using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Abstractions;
public interface IRecipeService
{
    Recipe? SelectedRecipe { get; set; }

    Task UpdateRecipesFromServerAsync();

    List<Recipe> ReadAllRecipes();
}

