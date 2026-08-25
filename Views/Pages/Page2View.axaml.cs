using SPW.ViewModels;

namespace SPW.Views;

public partial class Page2View : Page
{
    public Page2View()
    {
        InitializeComponent();
        
        DataContext = new Page2ViewModel("Привет");
    }
}