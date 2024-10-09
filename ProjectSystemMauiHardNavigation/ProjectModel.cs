using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Deadlines { get; set; }

        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
