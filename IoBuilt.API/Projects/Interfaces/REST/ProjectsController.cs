using System.Net.Mime;
using IoBuilt.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Model.Queries;
using IoBuilt.API.Projects.Domain.Services;
using IoBuilt.API.Projects.Interfaces.REST.Resources;
using IoBuilt.API.Projects.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IoBuilt.API.Projects.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Project Endpoints.")]
public class ProjectsController(IProjectQueryService projectQueryService, IProjectCommandService projectCommandService) : ControllerBase
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
    
    [HttpPost]
    [SwaggerOperation("Create a new Project", "Creates a new project.", OperationId = "CreateProject")]
    [SwaggerResponse(201, "Project created.", typeof(ProjectResource))]
    [SwaggerResponse(400, "The request is invalid.")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectResource resource)
    {
        var createProjectCommand = CreateProjectCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await projectCommandService.Handle(createProjectCommand);
        if (result is null) return BadRequest();
        var projectResource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetProjectById), new { projectId = projectResource.Id }, projectResource);
    }

    [HttpPut("{projectId:int}")]
    [SwaggerOperation("Update Project", "Updates an existing project.", OperationId = "UpdateProject")]
    [SwaggerResponse(200, "Project updated.", typeof(ProjectResource))]
    [SwaggerResponse(400, "The request is invalid.")]
    [SwaggerResponse(404, "The project was not found.")]
    public async Task<IActionResult> UpdateProject(int projectId, [FromBody] UpdateProjectResource resource)
    {
        try
        {
            var updateProjectCommand = UpdateProjectCommandFromResourceAssembler.ToCommandFromResource(resource, projectId);
            var result = await projectCommandService.Handle(updateProjectCommand);
            if (result is null) return BadRequest("Failed to update project.");
            var projectResource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(projectResource);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not found"))
                return NotFound("Project not found.");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{projectId:int}")]
    [SwaggerOperation("Delete Project", "Deletes an existing project.", OperationId = "DeleteProject")]
    [SwaggerResponse(204, "Project deleted.")]
    [SwaggerResponse(404, "The project was not found.")]
    [SwaggerResponse(400, "The request is invalid.")]
    public async Task<IActionResult> DeleteProject(int projectId)
    {
        try
        {
            var deleteProjectCommand = new DeleteProjectCommand(projectId);
            var result = await projectCommandService.Handle(deleteProjectCommand);
            if (!result) return BadRequest("Failed to delete project.");
            return NoContent();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not found"))
                return NotFound("Project not found.");
            return BadRequest(ex.Message);
        }
    }
}