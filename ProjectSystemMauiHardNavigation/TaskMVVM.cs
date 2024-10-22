using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation
{
    public class TaskMVVM: BaseVM
    {
        public List<ProjectModel> Projects { get; set; }

        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        public TaskModel SelectedTask { get; set; }

        public VmCommand AddTask {  get; set; }
        public VmCommand UpdateTask { get; set; }
        public VmCommand RemoveTask { get; set; }


        private async void UpdateList()
        {
            Tasks = await DB.GetInstance().GetTasks();
            Signal(nameof(Tasks));
        }

        public void OnAppearing()
        {
            UpdateList();
        }

        public TaskMVVM()
        {
            AddTask = new VmCommand(async () => 
            {
                ShellNavigationQueryParameters shellQuery = new ShellNavigationQueryParameters()

                {
                    { "TaskId", 0}
                };
                await Shell.Current.GoToAsync("EditTask", shellQuery);
            //await Navigation.PushAsync(new NewTaskWindow(new TaskModel()));
            });

            UpdateTask = new VmCommand(async () =>
            {
                ShellNavigationQueryParameters shellQuery = new ShellNavigationQueryParameters()

            {
                { "TaskId", SelectedTask.Id}
            };
                await Shell.Current.GoToAsync("EditTask", shellQuery);
                //await Navigation.PushAsync(new NewTaskWindow(SelectedTask));
            });

            RemoveTask = new VmCommand(async () =>
            {
                await DB.GetInstance().Delete(SelectedTask.Id);
                UpdateList();
            });
        }
    }
}
