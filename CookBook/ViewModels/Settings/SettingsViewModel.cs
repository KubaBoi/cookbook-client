using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.ViewModels.Settings;
public partial class SettingsViewModel : ViewModelBase
{
    private readonly ISettings _settings;
    private readonly INavigationService _navigationService;
    private readonly IFileService _fileService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public SettingsViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        Items = new ObservableCollection<SettingsItemViewModel>
        {
            new SettingsItemViewModel("name1", "value1"),
            new SettingsItemViewModel("name2", "value2"),
            new SettingsItemViewModel("name3dasdasdasdasdasdasdasdasdasdasd", "value3"),
            new SettingsItemViewModel("name4", "value4")
        };
    }

    public SettingsViewModel(
        ISettings settings,
        INavigationService navigationService,
        IFileService fileService)
    {
        _settings = settings;
        _navigationService = navigationService;
        _fileService = fileService;

        InitCommands();
        InitItems();
    }

    #region Properties

    [ObservableProperty]
    private ObservableCollection<SettingsItemViewModel>? _items;

    #endregion

    #region Commands

    [ObservableProperty]
    private ICommand? _goBackCommand;

    #endregion

    #region Command methods

    private void InitCommands()
    {
        GoBackCommand = new RelayCommand(GoBack);
    }

    private void GoBack()
    {
        _navigationService.Navigate(Services.Core.NavigationPath.RecipeDetail);
    }

    #endregion

    #region Private methods

    private void InitItems()
    {
        Items = new ObservableCollection<SettingsItemViewModel>
        {
            new SettingsItemViewModel("Verze", GetVersion()),
            new SettingsItemViewModel("AppDir", _fileService.GetAppDirectory().FullName),
            new SettingsItemViewModel("RecipeDir", _fileService.GetRecipeDirectory().FullName)
        };
    }

    private string GetVersion()
    {
        return Assembly.GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
            ?? "Unknown";
    }

    #endregion
}

