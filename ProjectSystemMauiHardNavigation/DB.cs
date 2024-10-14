
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSystemMauiHardNavigation
{
    public class DB
    {
        private static DB instance;

        private List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        private List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
        private List<User> Users { get; set; } = new();
        private ProjectModel Project { get; set; }

        private int lastid = 1;
        private int plastid = 1;
        private int ulastid = 1;
        public DB()
        {
            Tasks.Add(new TaskModel
            {
                Id = 1,
                Title = "апавпавп",
                Description = "dsgfdsgrsg"
            });

            Projects.Add(new ProjectModel
            {
                Id = 1,
                Title = "апавпавп",
                Deadlines = 5
            });

            Users.Add(new User
            {
                Id = 1,
                FirstName = "Alena",
                LastName = "Nikitina",
                Password = "123456"
            });
        }
        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            List<TaskModel> taskModels = new List<TaskModel>(Tasks);
            await Task.Delay(1000);
            return taskModels;
        }

       
        public async Task<TaskModel> TaskById(int id)
        {
            var task = Tasks.FirstOrDefault(s  => s.Id == id);
            TaskModel model = new TaskModel
            {
                 Id = task.Id,
                 Title = task.Title,
                 Description = task.Description,
                 ProjectId = task.ProjectId,
                 Project = task.Project
            };
            await Task.Delay(1000);
            return task;
        }

        public async Task NewTask(TaskModel task)
        {
            await Task.Delay(1000);
            TaskModel newTask = new TaskModel()
            {
                Id = ++lastid,
                Title = task.Title,
                Description = task.Description,
                ProjectId = task.ProjectId,
                Project = task.Project
            }; 
            Tasks.Add(newTask);
            newTask.Project.Tasks.Add(newTask);
        }

        public async Task Update( TaskModel task1)
        {
            //var task1 = TaskById(id);
            var task = Tasks.FirstOrDefault(s => s.Id == task1.Id);
            task.Title = task1.Title;
            task.Description = task1.Description;
            task.ProjectId = task1.ProjectId;
            task.Project = task1.Project;
            await Task.Delay(1000);
        }

        public async Task Delete(int id)
        {
            var task = Tasks.FirstOrDefault(s => s.Id == id);
            await Task.Delay(1000);
            Tasks.Remove(task);
            task.Project.Tasks.Remove(task);
        }







        public async Task<List<ProjectModel>> GetProjects()
        {
            List<ProjectModel> projectModels = new List<ProjectModel>(Projects);
            await Task.Delay(100);
            return projectModels;
        }


        public async Task<ProjectModel> ProjectById(int id)
        {
            var project = Projects.FirstOrDefault(s => s.Id == id);
            ProjectModel model = new ProjectModel
            {
                Id = project.Id,
                Title = project.Title,
                Deadlines = project.Deadlines,
                Tasks = project.Tasks
            };
            await Task.Delay(1000);
            return project;
        }

        public async Task NewProject(ProjectModel project)
        {
            await Task.Delay(1000);
            ProjectModel newProject = new ProjectModel()
            {
                Id = ++plastid,
                Title = project.Title,
                Deadlines = project.Deadlines,
                Tasks = project.Tasks
            };
            Projects.Add(newProject);
        }

        public async Task UpdateProject(ProjectModel project1)
        {
            var project = Projects.FirstOrDefault(s => s.Id == project1.Id);
            project.Title = project1.Title;
            project.Deadlines = project1.Deadlines;
            project.Tasks = project1.Tasks;
            await Task.Delay(1000);
        }

        public async Task DeleteProject(int id)
        {
            var project = Projects.FirstOrDefault(s => s.Id == id);
            await Task.Delay(1000);

            Projects.Remove(project);
        }
    }
}
