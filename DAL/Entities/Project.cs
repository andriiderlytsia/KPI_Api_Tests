using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
