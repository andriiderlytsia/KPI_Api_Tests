using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        ITaskService taskService;

        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger, ITaskService service)
        {
            taskService = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskService.GetProjects());
        }

        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var projectDTO = taskService.GetProject(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO,ProjectModel >()).CreateMapper();
            var project = mapper.Map<ProjectDTO, ProjectModel>(projectDTO);
            return Ok(project);
        }
        [HttpPost("AddProject")]
        public IActionResult AddProject(ProjectModel project)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectModel, ProjectDTO>()).CreateMapper();
            var projectAdd = mapper.Map<ProjectModel, ProjectDTO>(project);
            taskService.AddProject(projectAdd);
            return Ok(project);
        }
        [HttpPut]
        public IActionResult Put(ProjectModel project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectModel, ProjectDTO>()).CreateMapper();
            var projectDTO = mapper.Map<ProjectModel, ProjectDTO>(project);
            taskService.UpdateProject(projectDTO);
            return Ok(project);
        }
            [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {

            var project = taskService.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            taskService.DeleteProject(id);
            return Ok(project);
        }

    }
}
