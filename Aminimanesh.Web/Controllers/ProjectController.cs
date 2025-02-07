using Aminimanesh.Core.DTOs.ProjectDTOs;
using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Aminimanesh.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("projects/{name}")]
        public async Task<IActionResult> ShowProject(string name)
        {
            var project = await _projectService.GetProjectByNameAsync(name);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public async Task<IActionResult> GetProjects(int categoryId)
        {
            var projects = await _projectService.GetProjectsAsync(categoryId);
            return PartialView(projects);
        }
    }
}
