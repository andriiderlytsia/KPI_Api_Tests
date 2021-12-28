using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int Priority { get; set; }
        public bool Status { get; set; }

        public int ProjectId { get; set; }
    }
}
