using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ITaskService
    {
        void MakeTask(TaskDTO taskDto);
        ProjectDTO GetProject(int? id);
        IEnumerable<TaskDTO> GetTasksByProjectID(int? id);
        IEnumerable<TaskDTO> GetTasks();
        TaskDTO GetTask(int? id);
        void DeleteTask(int? id);
        void UpdateProject(ProjectDTO projectDTO);
        void DeleteProject(int? id);
        void AddProject(ProjectDTO projectDTO);
        IEnumerable<ProjectDTO> GetProjects();
        void Dispose();
    }
}
