
namespace ProjectSystemMauiHardNavigation;

public partial class NewTaskWindow : ContentPage, IQueryAttributable
{
    public TaskModel TaskM { get; set; }

    public List<ProjectModel> Projects { get; set; }

    public ProjectModel Project { get; set; }

    public NewTaskWindow()
    {
        InitializeComponent();
        
        
        //Project = Projects.FirstOrDefault(s => s.Id == TaskM.ProjectId);
    }

    private async void UpdateList()
    {
        Projects = await DB.GetInstance().GetProjects();
        if (TaskM.Project != null)
        {
            Project = Projects.FirstOrDefault(s => s.Id == TaskM.ProjectId);
        }

        OnPropertyChanged(nameof(Projects));
        OnPropertyChanged(nameof(Project));
    }

    private async void SaveClick(object sender, EventArgs e)
    {
        if (Project != null)
        {
            TaskM.Project = Project;
            TaskM.ProjectId = TaskM.Project.Id;
        }


        if (TaskM == null || TaskM.Id == 0)
        {
            await DB.GetInstance().NewTask(TaskM);
            await Navigation.PopAsync();
        }
        else
        {
            await DB.GetInstance().Update(TaskM);
            await Navigation.PopAsync();
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        int id = (int)query["TaskId"];
        if (id == 0)
        {
            TaskM = new TaskModel();
        }
        else
            TaskM = await DB.GetInstance().TaskById(id);
        UpdateList();
        BindingContext = this;
        //await DisplayAlert("fdfdf", query["SelectedTask"].ToString(), "SelectedTask");
    }
}