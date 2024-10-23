using ProjectSystemMauiHardNavigation.ViewModel;

namespace ProjectSystemMauiHardNavigation;

public partial class ProjectPage : ContentPage
{

    
    public ProjectPage()
    {
        InitializeComponent();
        
        //BindingContext = new ProjectMVVM();

    }

   

    protected override void OnAppearing()
    {
        ((ProjectMVVM)BindingContext).OnAppearing();
    }

    

    
}