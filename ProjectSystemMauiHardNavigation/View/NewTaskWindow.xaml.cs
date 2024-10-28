
using ProjectSystemMauiHardNavigation.ViewModel;

namespace ProjectSystemMauiHardNavigation;

public partial class NewTaskWindow : ContentPage
{

    public NewTaskWindow()
    {
        InitializeComponent();

        BindingContext = new NewTaskMVVM();

        //Project = Projects.FirstOrDefault(s => s.Id == TaskM.ProjectId);
    }
    protected override void OnAppearing()
    {
        ((NewTaskMVVM)BindingContext).OnAppearing();
    }


}