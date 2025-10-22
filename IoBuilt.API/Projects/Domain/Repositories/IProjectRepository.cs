using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Domain.Repositories;

public interface IProjectRepository : IBaseRepository<Project>
{
    Task<IEnumerable<Project>> FindByBuilderIdAsync(int builderId);
    Task<IEnumerable<Project>> FindByStatusAsync(string status);
}