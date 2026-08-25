using ReactiveUI.SourceGenerators;

namespace SPW.ViewModels;

public partial class Page1ViewModel : PageViewModelBase
{
    [Reactive] private bool _isEnabled = false;
    public Page1ViewModel(string text) 
        : base(text)
    { }

    [ReactiveCommand]
    private void Edit()
    {
        IsEnabled = true;
    }
}