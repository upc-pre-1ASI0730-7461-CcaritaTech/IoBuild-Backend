using IoBuilt.API.Analytics.Interfaces.ACL;
using IoBuilt.API.Projects.Domain.Repositories;

namespace IoBuilt.API.Analytics.Application.ACL;

public class ProjectsContextFacade : IProjectsContextFacade
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitRepository _unitRepository;

    public ProjectsContextFacade(IProjectRepository projectRepository, IUnitRepository unitRepository)
    {
        _projectRepository = projectRepository;
        _unitRepository = unitRepository;
    }

    public async Task<IEnumerable<int>> GetProjectIdsByBuilderIdAsync(int builderId)
    {
        var projects = await _projectRepository.FindByBuilderIdAsync(builderId);
        return projects.Select(p => p.Id);
    }

    public async Task<IEnumerable<int>> GetProjectIdsByOwnerIdAsync(int ownerId)
    {
        var units = await _unitRepository.FindByOwnerIdAsync(ownerId);
        return units.Select(u => u.ProjectId).Distinct();
    }

    public async Task<bool> ProjectExistsAsync(int projectId)
    {
        var project = await _projectRepository.FindByIdAsync(projectId);
        return project != null;
    }

    public async Task<Projects.Domain.Model.Aggregates.Project?> GetProjectByIdAsync(int projectId)
    {
        return await _projectRepository.FindByIdAsync(projectId);
    }

    public async Task<IEnumerable<Projects.Domain.Model.Aggregates.Unit>> GetUnitsByOwnerIdAsync(int ownerId)
    {
        return await _unitRepository.FindByOwnerIdAsync(ownerId);
    }
}
