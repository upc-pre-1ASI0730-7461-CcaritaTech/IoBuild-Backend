using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.ValueObjects;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Implements the project repository for Entity Framework Core persistence.
/// 
/// This class provides data access operations for Project entities, extending the base repository
/// with domain-specific queries for retrieving projects based on builder, status, and name criteria.
/// </summary>
public class ProjectRepository(AppDbContext context) : BaseRepository<Project>(context), IProjectRepository
{
    /// <summary>
    /// Asynchronously retrieves all projects owned by a specific builder.
    /// </summary>
    /// <param name="builderId">The unique identifier of the builder.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of projects owned by the specified builder.</returns>
    public async Task<IEnumerable<Project>> FindByBuilderIdAsync(int builderId)
    {
        return await Context.Set<Project>().Where(p => p.BuilderId == builderId).ToListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves all projects with a specific status.
    /// </summary>
    /// <param name="status">The project status to filter by.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of projects with the specified status.</returns>
    public async Task<IEnumerable<Project>> FindByStatusAsync(EProjectStatus status)
    {
        return await Context.Set<Project>().Where(p => p.Status == status).ToListAsync();
    }
    
    /// <summary>
    /// Asynchronously retrieves a project by its name.
    /// </summary>
    /// <param name="name">The name of the project to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the project with the specified name, or null if no project with that name exists.</returns>
    public async Task<Project?> FindByNameAsync(string name)
    {
        return await Context.Set<Project>().Where(p => p.Name == name).FirstOrDefaultAsync();
    }
}