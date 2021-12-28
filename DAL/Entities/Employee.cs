using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialization { get; set; }
        public Project Project { get; set; }
    }
}
