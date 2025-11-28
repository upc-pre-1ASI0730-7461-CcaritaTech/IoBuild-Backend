using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Domain.Model.Queries;

namespace IoBuilt.API.Clients.Domain.Services;

public interface IClientQueryService
{
    Task<IEnumerable<Client>> Handle(GetAllClientsQuery query);
    Task<Client?> Handle(GetClientByIdQuery query);
    Task<IEnumerable<Client>> Handle(GetClientsByProjectIdQuery query);
    Task<IEnumerable<Client>> Handle(GetClientsByAccountStatementQuery query);
}
