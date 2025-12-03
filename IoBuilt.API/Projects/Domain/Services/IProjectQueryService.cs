using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;

namespace IoBuilt.API.Projects.Domain.Services;

/// <summary>
/// Defines the contract for handling query operations on projects.
/// 
/// This interface specifies the methods for executing domain queries that retrieve
/// project data without modifying the system state.
/// </summary>
public interface IProjectQueryService
{
    /// <summary>
    /// Asynchronously handles a query to retrieve all projects.
    /// </summary>
    /// <param name="query">The query object requesting all projects.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of all projects in the system.</returns>
    Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query);

    /// <summary>
    /// Asynchronously handles a query to retrieve a specific project by its identifier.
    /// </summary>
    /// <param name="query">The query object containing the project identifier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the project with the specified identifier, or null if no such project exists.</returns>
    Task<Project?> Handle(GetProjectByIdQuery query);
}