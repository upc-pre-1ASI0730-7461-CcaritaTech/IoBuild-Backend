using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Interfaces.REST.Resources;

namespace IoBuilt.API.Clients.Interfaces.REST.Transform;

public static class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client entity)
    {
        return new ClientResource(
            entity.Id,
            entity.FullName,
            entity.ProjectId,
            entity.ProjectName,
            entity.AccountStatement.ToString(),
            entity.Email,
            entity.PhoneNumber,
            entity.Address);
    }
}

