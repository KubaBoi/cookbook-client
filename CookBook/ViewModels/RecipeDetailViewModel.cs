using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.ViewModels;
public partial class RecipeDetailViewModel : ViewModelBase
{
    public RecipeDetailViewModel()
    {

    }

    [ObservableProperty]
    public string _text = "Koláč s čokoládou";
}

