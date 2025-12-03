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

/// <summary>
/// Provides REST API endpoints for managing projects.
/// 
/// This controller handles HTTP requests related to project operations including
/// retrieval, creation, updating, and deletion of projects.
/// Requires authorization for all endpoints.
/// </summary>
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Project Endpoints.")]
public class ProjectsController(IProjectQueryService projectQueryService, IProjectCommandService projectCommandService) : ControllerBase
{
    /// <summary>
    /// Retrieves a specific project by its unique identifier.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// an IActionResult with the project resource if found, or a 404 Not Found response.</returns>
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

    /// <summary>
    /// Retrieves all projects in the system.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// an IActionResult with a collection of project resources.</returns>
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
    
    /// <summary>
    /// Creates a new project.
    /// </summary>
    /// <param name="resource">The project creation resource containing the project details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// an IActionResult with the created project resource and a 201 Created status, or a 400 Bad Request response.</returns>
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

    /// <summary>
    /// Updates an existing project.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project to update.</param>
    /// <param name="resource">The project update resource containing the updated project details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// an IActionResult with the updated project resource, or appropriate error responses.</returns>
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

    /// <summary>
    /// Deletes an existing project.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// an IActionResult with a 204 No Content status if successful, or appropriate error responses.</returns>
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