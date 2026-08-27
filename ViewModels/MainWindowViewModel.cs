using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using ReactiveUI.SourceGenerators;
using SPW.Views;

namespace SPW.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ImmutableList<ItemOfPages> Pages { get; } = 
    [
        new()
        {
            Title = "Page 1",
            View = new Page1View()
        },
        new()
        {
            Title = "Page 2",
            View = new Page2View()
        }
    ];

    [Reactive] private ItemOfPages _selectedPage;

    public MainWindowViewModel()
    {
        SelectedPage = Pages[0];
    }
}

public class ItemOfPages
{
    public string Title { get; set; }
    public ContentControl View { get; set; }
}