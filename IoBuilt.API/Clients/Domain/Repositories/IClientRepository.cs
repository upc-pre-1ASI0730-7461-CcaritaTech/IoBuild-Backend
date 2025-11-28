using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Domain.Model.ValueObjects;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Clients.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
    Task<IEnumerable<Client>> FindByProjectIdAsync(int projectId);
    Task<IEnumerable<Client>> FindByAccountStatementAsync(EAccountStatement accountStatement);
    Task<Client?> FindByEmailAsync(string email);
}
