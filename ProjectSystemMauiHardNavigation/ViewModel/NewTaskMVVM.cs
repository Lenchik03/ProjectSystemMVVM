using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectSystemMauiHardNavigation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation.ViewModel
{
    public class NewTaskMVVM : BaseVM, IQueryAttributable
    {
        public VmCommand Save { get; set; }

        public TaskModel TaskM { get; set; }

        public List<ProjectModel> Projects { get; set; }

        public ProjectModel Project { get; set; }

        public NewTaskMVVM()
        {
            Save = new VmCommand(async () =>
            {
                if (Project != null)
                {
                    TaskM.Project = Project;
                    TaskM.ProjectId = TaskM.Project.Id;
                }


                if (TaskM == null || TaskM.Id == 0)
                {
                    await DB.GetInstance().NewTask(TaskM);
                    await Shell.Current.GoToAsync("//TasksPage");
                }
                else
                {
                    await DB.GetInstance().Update(TaskM);
                    await Shell.Current.GoToAsync("//TasksPage");
                }
            });
        }

        private async void UpdateList()
        {
            Projects = await DB.GetInstance().GetProjects();
            if (TaskM.Project != null)
            {
                Project = Projects.FirstOrDefault(s => s.Id == TaskM.ProjectId);
            }

            Signal(nameof(Project));
            Signal(nameof(Projects));
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
            Signal(nameof(TaskM));
            //BindingContext = this;
            //await DisplayAlert("fdfdf", query["SelectedTask"].ToString(), "SelectedTask");
        }



    }
}
