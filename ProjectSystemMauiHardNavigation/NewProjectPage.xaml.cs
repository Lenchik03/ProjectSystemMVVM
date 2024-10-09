namespace ProjectSystemMauiHardNavigation;

public partial class NewProjectPage : ContentPage
{
    public ProjectModel Project { get; set; }

    public NewProjectPage(ProjectModel project)
    {
        InitializeComponent();
        this.Project = project;
        BindingContext = this;
    }

    public void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        header.Text = $"Выбрано: {e.NewValue:F1}";
        double value = ((Slider)sender).Value;
        Project.Deadlines = value;
    }

    private async void SaveClick(object sender, EventArgs e)
    {

        if (Project == null || Project.Id == 0)
        {
            await DB.GetInstance().NewProject(Project);
            await Navigation.PopAsync();
        }
        else
        {
            await DB.GetInstance().UpdateProject(Project);
            await Navigation.PopAsync();
        }
    }
}