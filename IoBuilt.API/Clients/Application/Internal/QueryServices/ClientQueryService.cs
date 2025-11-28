using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Domain.Model.Queries;
using IoBuilt.API.Clients.Domain.Repositories;
using IoBuilt.API.Clients.Domain.Services;

namespace IoBuilt.API.Clients.Application.Internal.QueryServices;

public class ClientQueryService(IClientRepository clientRepository) : IClientQueryService
{
    public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery query)
    {
        return await clientRepository.ListAsync();
    }

    public async Task<Client?> Handle(GetClientByIdQuery query)
    {
        return await clientRepository.FindByIdAsync(query.ClientId);
    }

    public async Task<IEnumerable<Client>> Handle(GetClientsByProjectIdQuery query)
    {
        return await clientRepository.FindByProjectIdAsync(query.ProjectId);
    }

    public async Task<IEnumerable<Client>> Handle(GetClientsByAccountStatementQuery query)
    {
        return await clientRepository.FindByAccountStatementAsync(query.AccountStatement);
    }
}
