using System.Net.Mime;
using IoBuilt.API.Projects.Domain.Model.Queries;
using IoBuilt.API.Projects.Domain.Services;
using IoBuilt.API.Projects.Interfaces.REST.Resources;
using IoBuilt.API.Projects.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IoBuilt.API.Projects.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Project Endpoints.")]
public class ProjectsController(IProjectQueryService projectQueryService) : ControllerBase
{
    [HttpGet("{projectId:int}")]
    [SwaggerOperation("Get Project by Id", "Get a project by its unique identifier.", OperationId = "GetProjectById")]
    [SwaggerResponse(200, "The project was found and returned.", typeof(ProjectResource))]
    [SwaggerResponse(404, "The project was not found.")]
    public async Task<IActionResult> GetProjectById(int projectId)
    {
        var getProjectByIdQuery = new GetProjectByIdQuery(projectId);
        var project = await projectQueryService.Handle(getProjectByIdQuery);
        if (project is null) return NotFound();
        var projectResource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(projectResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Projects", "Get all projects.", OperationId = "GetAllProjects")]
    [SwaggerResponse(200, "The projects were found and returned.", typeof(IEnumerable<ProjectResource>))]
    public async Task<IActionResult> GetAllProjects()
    {
        var getAllProjectsQuery = new GetAllProjectsQuery();
        var projects = await projectQueryService.Handle(getAllProjectsQuery);
        var projectResources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(projectResources);
    }
}