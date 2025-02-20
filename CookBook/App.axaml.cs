using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CookBook.Models;
using CookBook.Models.Settings;
using CookBook.Services.Abstractions;
using CookBook.Services.Core;
using CookBook.ViewModels;
using CookBook.ViewModels.RecipeDetail;
using CookBook.ViewModels.Timers;
using CookBook.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

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

        var services = new ServiceCollection();
        AddSettings(services);
        AddCommonServices(services);

        var serv = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = serv.GetRequiredService<MainWindow>();
        }
        //else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        //{
        //    singleViewPlatform.MainView = serv.GetRequiredService<MainView>();
        //}

        base.OnFrameworkInitializationCompleted();
    }

    private void AddSettings(IServiceCollection services)
    {
        var appsettings = new FileInfo(Constants.APP_SETTING_PATH);
        if (appsettings.Exists is false) return;

        using var stream = appsettings.OpenText();
        var data = stream.ReadToEnd();
        var settings = JsonSerializer.Deserialize<Settings>(data);
        if (settings is not null)
            services.AddSingleton(typeof(ISettings), settings);
    }

    private void AddCommonServices(IServiceCollection services)
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IHttpService, HttpService>();
        services.AddSingleton<IRecipeService, RecipeService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<ITimerService, TimerService>();
        services.AddSingleton<ISettingsService, SettingsService>();

        //services.AddView<MainView, MainViewModel>(ServiceLifetime.Singleton);
        services.AddView<RecipeDetailView, RecipeDetailViewModel>();
        services.AddView<TimersView, TimersViewModel>();

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();
    }
}

public static class Ext
{
    public static IServiceCollection AddView<TView, TViewModel>(this IServiceCollection services,
                                                                ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where TView : UserControl where TViewModel : ViewModelBase
    {
        services.Add(new ServiceDescriptor(typeof(TView), typeof(TView), ServiceLifetime.Transient));
        services.Add(new ServiceDescriptor(typeof(TViewModel), typeof(TViewModel), ServiceLifetime.Transient));
        return services;
    }
}
