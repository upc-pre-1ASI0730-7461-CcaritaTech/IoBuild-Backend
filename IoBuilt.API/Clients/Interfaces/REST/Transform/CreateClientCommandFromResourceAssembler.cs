using IoBuilt.API.Clients.Domain.Model.Commands;
using IoBuilt.API.Clients.Domain.Model.ValueObjects;
using IoBuilt.API.Clients.Interfaces.REST.Resources;

namespace IoBuilt.API.Clients.Interfaces.REST.Transform;

public static class CreateClientCommandFromResourceAssembler
{
    public static CreateClientCommand ToCommandFromResource(CreateClientResource resource)
    {
        var accountStatement = Enum.Parse<EAccountStatement>(resource.AccountStatement);
        
        return new CreateClientCommand(
            resource.FullName,
            resource.ProjectId,
            resource.ProjectName,
            accountStatement,
            resource.Email,
            resource.PhoneNumber,
            resource.Address);
    }
}

