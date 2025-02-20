using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.ViewModels.RecipeDetail;
public partial class StepViewModel : ObservableObject
{
    public StepViewModel(int index, string content)
    {
        Index = $"{index}.";
        Content = content;
    }

    [ObservableProperty]
    private string _index;

    [ObservableProperty]
    private string _content;
}

