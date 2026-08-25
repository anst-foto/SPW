using Avalonia.Controls;
using SPW.ViewModels;

namespace SPW.Views;

public partial class Page2View : UserControl
{
    public Page2View()
    {
        InitializeComponent();
        
        DataContext = new Page2ViewModel();
    }
}