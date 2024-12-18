﻿using Microsoft.EntityFrameworkCore;
using ProjectSystemMauiHardNavigation.Model;
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
            var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Database");
            Directory.CreateDirectory(sqlitePath);
            var fileName = $"{sqlitePath}\f{filename}";
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            optionsBuilder.UseSqlite($"Filename={fileName}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
