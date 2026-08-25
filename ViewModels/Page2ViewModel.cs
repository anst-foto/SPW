using ReactiveUI.SourceGenerators;

namespace SPW.ViewModels;

public partial class Page2ViewModel : ViewModelBase
{
    [Reactive] private string? _text = "Привет, мир!";
}