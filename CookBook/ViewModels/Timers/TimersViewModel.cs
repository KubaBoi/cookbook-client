using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.ViewModels.Timers;
public partial class TimersViewModel : ViewModelBase
{

    public TimersViewModel()
    {
        _title = "Timers";
    }

    [ObservableProperty]
    private string _title;
}

