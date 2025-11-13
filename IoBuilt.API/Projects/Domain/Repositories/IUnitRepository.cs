using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Domain.Repositories;

public interface IUnitRepository : IBaseRepository<Unit>
{
    Task<IEnumerable<Unit>> FindByProjectIdAsync(int projectId);
    Task<IEnumerable<Unit>> FindByOwnerIdAsync(int ownerId);
    Task<Unit?> FindByProjectIdAndUnitNumberAsync(int projectId, string unitNumber);
}
