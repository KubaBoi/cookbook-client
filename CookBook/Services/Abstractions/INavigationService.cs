using CookBook.Services.Core;

namespace CookBook.Services.Abstractions;
public interface INavigationService
{
    void Navigate(NavigationPath path);
}

