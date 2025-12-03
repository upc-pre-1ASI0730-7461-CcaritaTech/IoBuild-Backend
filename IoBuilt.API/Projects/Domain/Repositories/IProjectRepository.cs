using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.ValueObjects;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Domain.Repositories;

/// <summary>
/// Defines the contract for accessing and managing Project entities in the persistence layer.
/// 
/// This interface extends the base repository interface and adds domain-specific query methods
/// for retrieving projects based on different criteria such as builder, status, and name.
/// </summary>
public interface IProjectRepository : IBaseRepository<Project>
{
    /// <summary>
    /// Asynchronously retrieves all projects owned by a specific builder.
    /// </summary>
    /// <param name="builderId">The unique identifier of the builder.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of projects owned by the specified builder.</returns>
    Task<IEnumerable<Project>> FindByBuilderIdAsync(int builderId);

    /// <summary>
    /// Asynchronously retrieves all projects with a specific status.
    /// </summary>
    /// <param name="status">The project status to filter by.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of projects with the specified status.</returns>
    Task<IEnumerable<Project>> FindByStatusAsync(EProjectStatus status);

    /// <summary>
    /// Asynchronously retrieves a project by its name.
    /// </summary>
    /// <param name="name">The name of the project to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the project with the specified name, or null if no project with that name exists.</returns>
    Task<Project?> FindByNameAsync(string name);
}