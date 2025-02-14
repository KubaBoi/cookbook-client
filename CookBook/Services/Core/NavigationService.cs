using CookBook.Services.Abstractions;
using CookBook.ViewModels;
using System;
using System.Collections.Generic;

namespace CookBook.Services.Core;
public class NavigationService : INavigationService
{
    Action<NavigationPath>? _handler;

    public void SetNavigationChangeHandler(Action<NavigationPath>? handler)
    {
        _handler = handler;
    }

    public void Navigate(NavigationPath path)
    {
        if (_handler is not null)
        {
            _handler(path);
        }
    }
}

public enum NavigationPath
{
    RecipeDetail,
    RecipeSelection,
    Timers
}

