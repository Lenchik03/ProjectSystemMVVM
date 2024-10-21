using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation
{
    internal class DBBContext: DbContext
    {
        private readonly string filename;

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        public DBBContext(string filename)
        {
            this.filename = filename;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(filename);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
