using IoBuilt.API.Projects.Domain.Model.Aggregates;

namespace IoBuilt.API.Analytics.Interfaces.ACL;

public interface IProjectsContextFacade
{
    Task<IEnumerable<int>> GetProjectIdsByBuilderIdAsync(int builderId);
    Task<IEnumerable<int>> GetProjectIdsByOwnerIdAsync(int ownerId);
    Task<bool> ProjectExistsAsync(int projectId);
    Task<Project?> GetProjectByIdAsync(int projectId);
    Task<IEnumerable<Unit>> GetUnitsByOwnerIdAsync(int ownerId);
}
