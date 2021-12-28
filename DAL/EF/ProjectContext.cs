using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            //    this.connectionString = options;
            Database.EnsureCreated();

        }

        
    }
}
