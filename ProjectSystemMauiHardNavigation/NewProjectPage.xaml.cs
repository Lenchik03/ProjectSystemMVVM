namespace ProjectSystemMauiHardNavigation;
[QueryProperty(nameof(ProjectId), "ProjectId")]

public partial class NewProjectPage : ContentPage
{
    private int projectId;

    public ProjectModel Project { get; set; }

    public int ProjectId
    {
        get => projectId;
        set
        {
            projectId = value;
            if(ProjectId == 0)
                Project = new ProjectModel();
            else
                GetProjectById(projectId);
        }
    }

    private async void GetProjectById(int projectId)
    {
        Project = await DB.GetInstance().ProjectById(projectId);
    }

    public NewProjectPage()
    {
        InitializeComponent();

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