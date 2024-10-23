using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSystemMauiHardNavigation.Model;

namespace ProjectSystemMauiHardNavigation.ViewModel
{
    [QueryProperty(nameof(ProjectId), "ProjectId")]
    public class NewProjectMVVM
    {
        private int projectId;
        public VmCommand Save { get; set; }

        public string Text { get; set; }

        public ProjectModel Project { get; set; }

        public int ProjectId
        {
            get => projectId;
            set
            {
                projectId = value;
                if (ProjectId == 0)
                    Project = new ProjectModel();
                else
                    GetProjectById(projectId);
            }
        }
        public NewProjectMVVM()
        {
            Save = new VmCommand(async () =>
            {

                if (Project == null || Project.Id == 0)
                {
                    await DB.GetInstance().NewProject(Project);
                    await Shell.Current.GoToAsync("//ProjectsPage");
                }
                else
                {
                    await DB.GetInstance().UpdateProject(Project);
                    await Shell.Current.GoToAsync("//ProjectsPage");
                }
            });

        }
        private async void GetProjectById(int projectId)
        {
            Project = await DB.GetInstance().ProjectById(projectId);
        }



        public void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            Text = $"Выбрано: {e.NewValue:F1}";
            double value = ((Slider)sender).Value;
            Project.Deadlines = value;
        }


    }
}
