using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CookBook.Services.Abstractions;
using CookBook.Services.Core;
using CookBook.ViewModels;
using CookBook.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

namespace CookBook;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        var collection = new ServiceCollection();
        AddCommonServices(collection);

        var services = collection.BuildServiceProvider();

        var vm = services.GetRequiredService<MainViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void AddCommonServices(IServiceCollection collection)
    {
        collection.AddSingleton<IFileService, FileService>();
        collection.AddSingleton<IHttpService, HttpService>();
        collection.AddSingleton<IRecipeService, RecipeService>();

        collection.AddTransient<RecipeDetailView>();

        collection.AddTransient<MainViewModel>();
        collection.AddTransient<RecipeDetailViewModel>();
    }
}
