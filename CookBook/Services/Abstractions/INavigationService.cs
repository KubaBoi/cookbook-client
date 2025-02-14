using CookBook.Services.Core;
using System;

namespace CookBook.Services.Abstractions;
public interface INavigationService
{
    void SetNavigationChangeHandler(Action<NavigationPath>? handler);
    void Navigate(NavigationPath path);
}

