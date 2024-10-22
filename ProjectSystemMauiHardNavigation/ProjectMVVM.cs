using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation
{
    public class ProjectMVVM : BaseVM
    {
        public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
        public ProjectModel SelectedProject { get; set; }
        public VmCommand AddProject { get; set; }
        public VmCommand UpdateProject { get; set; }
        public VmCommand RemoveProject { get; set; }

        public List<TaskModel> Tasks { get; set; }

        public ProjectMVVM()
        {
            AddProject = new VmCommand(async () =>
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>
                {
                    {"ProjectId", SelectedProject.Id}
                };

                await Shell.Current.GoToAsync("EditProject", dictionary);
                //await Navigation.PushAsync(new NewProjectPage(new ProjectModel()));
            });

            UpdateProject = new VmCommand(async () =>
            {
                    Dictionary<string, object> dictionary = new Dictionary<string, object>
                    {
                        {"ProjectId", SelectedProject.Id}
                    };

                await Shell.Current.GoToAsync("EditProject", dictionary);
                //await Navigation.PushAsync(new NewProjectPage(SelectedProject));
            });

            RemoveProject = new VmCommand(async () =>
            {
                if (SelectedProject.Tasks.Count > 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Перед тем как удалить проект - удалите все задачи, входящие в этот проект", "Отмена");
                }
                else
                {
                    await DB.GetInstance().DeleteProject(SelectedProject.Id);
                    UpdateList();
                }

            });
        }

        private async void UpdateList()
        {
            Projects = await DB.GetInstance().GetProjects();

            Signal(nameof(Projects));

            //if(SelectedProject != null)
            //{
            //    Tasks = SelectedProject.Tasks;
            //    OnPropertyChanged(nameof(Tasks));
            //}
        }

        public void OnAppearing()
        {
            UpdateList();
        }

    }
    }
