using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        IUnitOfWork Database { get; set; }
        public TaskService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ProjectDTO GetProject(int? id)
        {

            var project = Database.Projects.Get(id.Value);

            if (project != null)
            {
                //var i = project.Tasks.Count;
                return new ProjectDTO { Id = project.Id, Title = project.Title };
            }
            else
                return null;
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();

            var project = Database.Projects.GetAll();
            if (project != null)
            {
                var result = Database.Projects.GetAll().ToList();
                return configuration.Map<IEnumerable<Project>, List<ProjectDTO>>(result);
            }
            else
                throw new ValidationException("Data empty");

        }
        public IEnumerable<TaskDTO> GetTasks()
        {
            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Task, TaskDTO>()).CreateMapper();

            var task = Database.Tasks.GetAll();
            if (task != null)
            {
                var result = Database.Tasks.GetAll().ToList();
                return configuration.Map<IEnumerable<Task>, List<TaskDTO>>(result);
            }
            else
                throw new ValidationException("Data empty");

        }
        public IEnumerable<TaskDTO> GetTasksByProjectID(int? id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>());
            var mapper = new Mapper(config);
            var tasks = mapper.Map<List<TaskDTO>>(Database.Tasks.Find(x => x.ProjectId == id.Value));
            return tasks;
        }

        public void UpdateProject(ProjectDTO projectDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, Project>()).CreateMapper();
            var project = mapper.Map<ProjectDTO, Project>(projectDTO);
            Database.Projects.Update(project);
            Database.Save();
        }
        //public IEnumerable<TaskDTO> GetTasks()
        //{
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>());
        //    var mapper = new Mapper(config);
        //    var alltasks = Database.Tasks.GetAll().ToList();
        //    var tasks = mapper.Map<List<TaskDTO>>(alltasks);
        //    return tasks;
        //}


        public void MakeTask(TaskDTO taskDto)
        {
            Project project = Database.Projects.Get(taskDto.ProjectId);
            if (project == null)
                throw new ValidationException("ProjectId is null");


            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<TaskDTO, Task>()).CreateMapper();
            var mapper = new Mapper(config.ConfigurationProvider);
            var task = mapper.Map<TaskDTO, Task>(taskDto);
            Database.Tasks.Create(task);
            Database.Save();
        }
        public void AddProject(ProjectDTO projectDTO)
        {

            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<ProjectDTO, Project>()).CreateMapper();
            var mapper = new Mapper(config.ConfigurationProvider);
            var project = mapper.Map<ProjectDTO, Project>(projectDTO);
            Database.Projects.Create(project);
            Database.Save();

        }
        public TaskDTO GetTask(int? id)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Task, TaskDTO>()).CreateMapper();

            var task = Database.Tasks.Get(id.Value);
            var mapper = new Mapper(config.ConfigurationProvider);
            TaskDTO taslDTO = mapper.Map<Task, TaskDTO>(task);
            return taslDTO;
        }
        public void DeleteTask(int? id)
        {
            Database.Tasks.Delete(id.Value);
            Database.Save();
        }
        public void DeleteProject(int? id)
        {
            Database.Projects.Delete(id.Value);
            Database.Save();
        }
    }
}
