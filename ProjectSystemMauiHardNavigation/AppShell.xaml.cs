namespace ProjectSystemMauiHardNavigation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("EditTask", typeof(NewTaskWindow));
            Routing.RegisterRoute("EditProject", typeof(NewProjectPage));
        }

        private async void LogOutClick(object sender, EventArgs e)
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
