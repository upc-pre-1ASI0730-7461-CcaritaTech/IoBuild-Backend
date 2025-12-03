using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;

namespace IoBuilt.API.Projects.Application.Internal.QueryServices;

/// <summary>
/// Implements the query service for retrieving project information.
/// 
/// This class handles the business logic for querying projects from the persistence layer.
/// It provides methods to retrieve all projects or a specific project by identifier.
/// </summary>
public class ProjectQueryService(IProjectRepository projectRepository) : IProjectQueryService
{
    /// <summary>
    /// Asynchronously retrieves all projects from the system.
    /// </summary>
    /// <param name="query">The query object requesting all projects.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of all projects in the system.</returns>
    public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query)
    {
        return await projectRepository.ListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves a specific project by its identifier.
    /// </summary>
    /// <param name="query">The query object containing the project identifier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the project with the specified identifier, or null if no such project exists.</returns>
    public async Task<Project?> Handle(GetProjectByIdQuery query)
    {
        return await projectRepository.FindByIdAsync(query.ProjectId);
    }
}