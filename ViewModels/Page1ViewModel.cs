using ReactiveUI.SourceGenerators;

namespace SPW.ViewModels;

public partial class Page1ViewModel : ViewModelBase
{
    [Reactive] private string? _text = "Hello, World!";
}