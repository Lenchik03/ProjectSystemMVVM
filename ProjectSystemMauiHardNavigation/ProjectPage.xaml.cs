namespace ProjectSystemMauiHardNavigation;

public partial class ProjectPage : ContentPage
{
    public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
    public ProjectModel SelectedProject { get; set; }

    public List<TaskModel> Tasks { get; set; }

    
    public ProjectPage()
    {
        InitializeComponent();
        
        UpdateList();
        BindingContext = this;

    }

    private async void UpdateList()
    {
        Projects = await DB.GetInstance().GetProjects();

        OnPropertyChanged(nameof(Projects));

        //if(SelectedProject != null)
        //{
        //    Tasks = SelectedProject.Tasks;
        //    OnPropertyChanged(nameof(Tasks));
        //}
    }

    protected override void OnAppearing()
    {
        UpdateList();
    }

    private async void NewProjectClick(object sender, EventArgs e)
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>
        {
            {"ProjectId", SelectedProject.Id}
        };

        await Shell.Current.GoToAsync("EditProject", dictionary);
        //await Navigation.PushAsync(new NewProjectPage(new ProjectModel()));
    }

    private async void UpdateProjectClick(object sender, EventArgs e)
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>
        {
            {"ProjectId", SelectedProject.Id}
        };

        await Shell.Current.GoToAsync("EditProject", dictionary);
        //await Navigation.PushAsync(new NewProjectPage(SelectedProject));
    }

    private async void DeleteProjectClick(object sender, EventArgs e)
    {
        if (SelectedProject.Tasks.Count > 0)
        {
            await DisplayAlert("Ошибка", "Перед тем как удалить проект - удалите все задачи, входящие в этот проект", "Отмена");
        }
        else
        {
            await DB.GetInstance().DeleteProject(SelectedProject.Id);
            UpdateList();
        }
    }

    
}