using SPW.ViewModels;

namespace SPW.Views;

public partial class Page1View : Page
{
    public Page1View()
    {
        InitializeComponent();
        
        DataContext = new Page1ViewModel("Hello");
    }
}