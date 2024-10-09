namespace ProjectSystemMauiHardNavigation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("EditTask", typeof(NewTaskWindow));
        }
    }
}
