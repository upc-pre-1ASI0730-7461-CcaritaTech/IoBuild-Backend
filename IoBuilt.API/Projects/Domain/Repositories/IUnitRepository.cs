using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Domain.Repositories;

/// <summary>
/// Defines the contract for accessing and managing Unit entities in the persistence layer.
/// 
/// This interface extends the base repository interface and adds domain-specific query methods
/// for retrieving units based on different criteria such as project, owner, and unit number.
/// </summary>
public interface IUnitRepository : IBaseRepository<Unit>
{
    /// <summary>
    /// Asynchronously retrieves all units that belong to a specific project.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of units belonging to the specified project.</returns>
    Task<IEnumerable<Unit>> FindByProjectIdAsync(int projectId);

    /// <summary>
    /// Asynchronously retrieves all units owned by a specific owner.
    /// </summary>
    /// <param name="ownerId">The unique identifier of the unit owner.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of units owned by the specified owner.</returns>
    Task<IEnumerable<Unit>> FindByOwnerIdAsync(int ownerId);

    /// <summary>
    /// Asynchronously retrieves a unit by its project identifier and unit number.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project.</param>
    /// <param name="unitNumber">The unit number within the project.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the unit with the specified project and unit number, or null if no such unit exists.</returns>
    Task<Unit?> FindByProjectIdAndUnitNumberAsync(int projectId, string unitNumber);
}
