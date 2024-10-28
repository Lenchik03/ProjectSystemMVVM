using ProjectSystemMauiHardNavigation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation.Model
{
    public class ProjectModel : BaseVM
    {
        private double deadlines;

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Deadlines
        {
            get => deadlines;
            set
            {
                deadlines = value;
                Signal();
            }
        }

        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

    }
}
