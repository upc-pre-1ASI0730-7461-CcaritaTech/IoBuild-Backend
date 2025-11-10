using IoBuilt.API.IAM.Domain.Model.Aggregates;
using IoBuilt.API.IAM.Interfaces.REST.Resources;

namespace IoBuilt.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Email, entity.Role);
    }
}