using IoBuilt.API.Clients.Domain.Model.Commands;
using IoBuilt.API.Clients.Domain.Model.ValueObjects;
using IoBuilt.API.Clients.Interfaces.REST.Resources;

namespace IoBuilt.API.Clients.Interfaces.REST.Transform;

public static class UpdateClientCommandFromResourceAssembler
{
    public static UpdateClientCommand ToCommandFromResource(UpdateClientResource resource, int clientId)
    {
        var accountStatement = Enum.Parse<EAccountStatement>(resource.AccountStatement);
        
        return new UpdateClientCommand(
            clientId,
            resource.FullName,
            resource.ProjectId,
            resource.ProjectName,
            accountStatement,
            resource.Email,
            resource.PhoneNumber,
            resource.Address);
    }
}

