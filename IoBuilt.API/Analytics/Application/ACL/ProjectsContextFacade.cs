using IoBuilt.API.Analytics.Interfaces.ACL;
using IoBuilt.API.Projects.Domain.Repositories;

namespace IoBuilt.API.Analytics.Application.ACL;

/// <summary>
/// Anti-Corruption Layer (ACL) facade for accessing Projects bounded context.
/// Translates and adapts Projects context operations for Analytics context consumption.
/// </summary>
public class ProjectsContextFacade : IProjectsContextFacade
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitRepository _unitRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectsContextFacade"/> class.
    /// </summary>
    /// <param name="projectRepository">Repository for accessing project data.</param>
    /// <param name="unitRepository">Repository for accessing unit data.</param>
    public ProjectsContextFacade(IProjectRepository projectRepository, IUnitRepository unitRepository)
    {
        _projectRepository = projectRepository;
        _unitRepository = unitRepository;
    }

    /// <summary>
    /// Retrieves all project IDs associated with a builder.
    /// </summary>
    /// <param name="builderId">The builder's unique identifier.</param>
    /// <returns>Collection of project IDs.</returns>
    public async Task<IEnumerable<int>> GetProjectIdsByBuilderIdAsync(int builderId)
    {
        var projects = await _projectRepository.FindByBuilderIdAsync(builderId);
        return projects.Select(p => p.Id);
    }

    /// <summary>
    /// Retrieves distinct project IDs where the owner has units.
    /// </summary>
    /// <param name="ownerId">The owner's unique identifier.</param>
    /// <returns>Collection of distinct project IDs.</returns>
    public async Task<IEnumerable<int>> GetProjectIdsByOwnerIdAsync(int ownerId)
    {
        var units = await _unitRepository.FindByOwnerIdAsync(ownerId);
        return units.Select(u => u.ProjectId).Distinct();
    }

    /// <summary>
    /// Checks if a project exists by its ID.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>True if project exists; otherwise false.</returns>
    public async Task<bool> ProjectExistsAsync(int projectId)
    {
        var project = await _projectRepository.FindByIdAsync(projectId);
        return project != null;
    }

    /// <summary>
    /// Retrieves a project by its ID.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Project aggregate if found; otherwise null.</returns>
    public async Task<Projects.Domain.Model.Aggregates.Project?> GetProjectByIdAsync(int projectId)
    {
        return await _projectRepository.FindByIdAsync(projectId);
    }

    /// <summary>
    /// Retrieves all units owned by a specific owner.
    /// </summary>
    /// <param name="ownerId">The owner's unique identifier.</param>
    /// <returns>Collection of units owned by the owner.</returns>
    public async Task<IEnumerable<Projects.Domain.Model.Aggregates.Unit>> GetUnitsByOwnerIdAsync(int ownerId)
    {
        return await _unitRepository.FindByOwnerIdAsync(ownerId);
    }
}
