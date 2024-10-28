
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectSystemMauiHardNavigation.Model;

namespace ProjectSystemMauiHardNavigation
{
    public class DB
    {
        private DBBContext bBContext = new DBBContext("Database");
        private static DB instance;

        
        private ProjectModel Project { get; set; }

        public DB()
        {
            bBContext.SaveChangesAsync();
        }
        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>(bBContext.Users);
            await Task.Delay(1000);
            return users;
        }

        public async Task NewUser(User user)
        {
            await Task.Delay(1000);
            User newuser = new User()
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password     
            };
            await bBContext.Users.AddAsync(newuser);
            await bBContext.SaveChangesAsync();
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            List<TaskModel> taskModels = new List<TaskModel>(bBContext.Tasks.Include(s => s.Project));
            await Task.Delay(1000);
            return taskModels;
        }

       
        public async Task<TaskModel> TaskById(int id)
        {
            var task = bBContext.Tasks.FirstOrDefault(s  => s.Id == id);
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
                Title = task.Title,
                Description = task.Description,
                ProjectId = task.ProjectId,
                Project = task.Project
            };
            await bBContext.Tasks.AddAsync(newTask);
            //var tasksIntoProject =  await bBContext.Tasks.Where(s => s.ProjectId == newTask.ProjectId).ToListAsync();

            newTask.Project.Tasks.Add(newTask);
            await bBContext.SaveChangesAsync();
        }

        public async Task Update( TaskModel task1)
        {
            //var task1 = TaskById(id);
            var task = bBContext.Tasks.FirstOrDefault(s => s.Id == task1.Id);
            task.Title = task1.Title;
            task.Description = task1.Description;
            task.ProjectId = task1.ProjectId;
            task.Project = task1.Project;
            await Task.Delay(1000);
            await bBContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var task = bBContext.Tasks.FirstOrDefault(s => s.Id == id);
            await Task.Delay(1000);
            bBContext.Tasks.Remove(task);
            task.Project.Tasks.Remove(task);
            await bBContext.SaveChangesAsync();
        }







        public async Task<List<ProjectModel>> GetProjects()
        {
            List<ProjectModel> projectModels = new List<ProjectModel>(bBContext.Projects);
            await Task.Delay(100);
            return projectModels;
        }


        public async Task<ProjectModel> ProjectById(int id)
        {
            var project = bBContext.Projects.FirstOrDefault(s => s.Id == id);
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
                Title = project.Title,
                Deadlines = project.Deadlines,
                Tasks = project.Tasks
            };
            await bBContext.Projects.AddAsync(newProject);
            await bBContext.SaveChangesAsync();
        }

        public async Task UpdateProject(ProjectModel project1)
        {
            var project = bBContext.Projects.FirstOrDefault(s => s.Id == project1.Id);
            project.Title = project1.Title;
            project.Deadlines = project1.Deadlines;
            project.Tasks = project1.Tasks;
            await Task.Delay(1000);
            await bBContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var project = bBContext.Projects.FirstOrDefault(s => s.Id == id);
            await Task.Delay(1000);

            bBContext.Projects.Remove(project);
            await bBContext.SaveChangesAsync();
        }
    }
}
