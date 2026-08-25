using Avalonia.Controls;
using SPW.ViewModels;

namespace SPW.Views;

public partial class Page1View : UserControl
{
    public Page1View()
    {
        InitializeComponent();
        
        DataContext = new Page1ViewModel("Hello");
    }
}