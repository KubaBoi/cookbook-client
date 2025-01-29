using CookBook.Exceptions;
using CookBook.Models;
using CookBook.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookBook.Services.Core;
public class RecipeService : IRecipeService
{
    private readonly IHttpService _httpService;
    private readonly IFileService _fileService;

    public Recipe? SelectedRecipe { get; set; }

    public RecipeService(
        IHttpService httpService,
        IFileService fileService)
    {
        _httpService = httpService;
        _fileService = fileService;
    }

    public async Task UpdateRecipesFromServerAsync()
    {
        var response = await _httpService.GetAsync("recipes", "get_all");

        string content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode is false)
        {
            throw new ServerException(response.StatusCode, content);
        }

        List<Recipe> recipes = JsonSerializer.Deserialize<List<Recipe>>(content);
        var dir = _fileService.GetRecipeDirectory();
        foreach (var recipe in recipes)
        {
            string data = JsonSerializer.Serialize(recipe);
            _fileService.WriteFile(dir, recipe.Id + ".json", data);
        }
    }

    public List<Recipe> ReadAllRecipes()
    {
        var dir = _fileService.GetRecipeDirectory();
        var files = dir.GetFiles();
        List<Recipe> recipes = new List<Recipe>(files.Length);
        foreach (var file in files)
        {
            var data = _fileService.ReadFile(file);
            recipes.Add(JsonSerializer.Deserialize<Recipe>(data));
        }
        return recipes;
    }
}

