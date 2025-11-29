using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Domain.Model.Commands;

namespace IoBuilt.API.Clients.Domain.Services;

public interface IClientCommandService
{
    Task<Client?> Handle(CreateClientCommand command);
    Task<Client?> Handle(UpdateClientCommand command);
    Task<bool> Handle(DeleteClientCommand command);
}
