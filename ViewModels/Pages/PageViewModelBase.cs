using ReactiveUI.SourceGenerators;

namespace SPW.ViewModels;

public abstract partial class PageViewModelBase : ViewModelBase
{
    [Reactive] private string _text;
    protected PageViewModelBase(string text)
    {
        Text = text;
    }
}