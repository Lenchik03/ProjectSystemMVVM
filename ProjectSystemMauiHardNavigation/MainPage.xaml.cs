namespace ProjectSystemMauiHardNavigation
{
    public partial class MainPage : ContentPage
    {
        public List<ProjectModel> Projects { get; set; }

        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        public TaskModel SelectedTask { get; set; }

     

        public MainPage()
        {
            InitializeComponent();

            UpdateList();
            BindingContext = this;
        }


        private async void UpdateList()
        {
            Tasks = await DB.GetInstance().GetTasks();
            OnPropertyChanged(nameof(Tasks));
        }

        protected override void OnAppearing()
        {
            UpdateList();
        }

        private async void NewTaskClick(object sender, EventArgs e)
        {
            ShellNavigationQueryParameters shellQuery = new ShellNavigationQueryParameters()

            {
                { "TaskId", 0}
            };
            await Shell.Current.GoToAsync("EditTask", shellQuery);
            //await Navigation.PushAsync(new NewTaskWindow(new TaskModel()));
        }

        private async void UpdateTaskClick(object sender, EventArgs e)
        {
            ShellNavigationQueryParameters shellQuery = new ShellNavigationQueryParameters()

            {
                { "TaskId", SelectedTask.Id}
            };
            await Shell.Current.GoToAsync("EditTask", shellQuery);
            //await Navigation.PushAsync(new NewTaskWindow(SelectedTask));
        }

        private async void DeleteTaskClick(object sender, EventArgs e)
        {
            await DB.GetInstance().Delete(SelectedTask.Id);
            UpdateList();
        }


        
    }

}
