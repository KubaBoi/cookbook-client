using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.ViewModels.Settings;
public partial class SettingsItemViewModel : ObservableObject
{

    public SettingsItemViewModel(string name, string value)
    {
        Name = name;
        Value = value;
    }

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _value;
}

