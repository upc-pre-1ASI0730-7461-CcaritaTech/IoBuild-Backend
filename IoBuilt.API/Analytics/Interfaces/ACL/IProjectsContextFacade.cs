using IoBuilt.API.Projects.Domain.Model.Aggregates;

namespace IoBuilt.API.Analytics.Interfaces.ACL;

/// <summary>
/// Interface defining the Anti-Corruption Layer for Projects bounded context.
/// Provides methods for Analytics context to query project and unit information.
/// </summary>
public interface IProjectsContextFacade
{
    /// <summary>
    /// Retrieves all project IDs associated with a builder.
    /// </summary>
    /// <param name="builderId">The builder's unique identifier.</param>
    /// <returns>Collection of project IDs.</returns>
    Task<IEnumerable<int>> GetProjectIdsByBuilderIdAsync(int builderId);
    
    /// <summary>
    /// Retrieves distinct project IDs where the owner has units.
    /// </summary>
    /// <param name="ownerId">The owner's unique identifier.</param>
    /// <returns>Collection of distinct project IDs.</returns>
    Task<IEnumerable<int>> GetProjectIdsByOwnerIdAsync(int ownerId);
    
    /// <summary>
    /// Checks if a project exists by its ID.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>True if project exists; otherwise false.</returns>
    Task<bool> ProjectExistsAsync(int projectId);
    
    /// <summary>
    /// Retrieves a project by its ID.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Project aggregate if found; otherwise null.</returns>
    Task<Project?> GetProjectByIdAsync(int projectId);
    
    /// <summary>
    /// Retrieves all units owned by a specific owner.
    /// </summary>
    /// <param name="ownerId">The owner's unique identifier.</param>
    /// <returns>Collection of units owned by the owner.</returns>
    Task<IEnumerable<Unit>> GetUnitsByOwnerIdAsync(int ownerId);
}
