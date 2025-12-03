using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Implements the unit repository for Entity Framework Core persistence.
/// 
/// This class provides data access operations for Unit entities, extending the base repository
/// with domain-specific queries for retrieving units based on project, owner, and unit number criteria.
/// </summary>
public class UnitRepository : BaseRepository<Unit>, IUnitRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public UnitRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Asynchronously retrieves all units that belong to a specific project.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of units belonging to the specified project.</returns>
    public async Task<IEnumerable<Unit>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<Unit>()
            .Where(u => u.ProjectId == projectId)
            .ToListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves all units owned by a specific owner.
    /// </summary>
    /// <param name="ownerId">The unique identifier of the unit owner.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of units owned by the specified owner.</returns>
    public async Task<IEnumerable<Unit>> FindByOwnerIdAsync(int ownerId)
    {
        return await Context.Set<Unit>()
            .Where(u => u.OwnerId == ownerId)
            .ToListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves a unit by its project identifier and unit number.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project.</param>
    /// <param name="unitNumber">The unit number within the project.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the unit with the specified project and unit number, or null if no such unit exists.</returns>
    public async Task<Unit?> FindByProjectIdAndUnitNumberAsync(int projectId, string unitNumber)
    {
        return await Context.Set<Unit>()
            .FirstOrDefaultAsync(u => u.ProjectId == projectId && u.UnitNumber == unitNumber);
    }
}
