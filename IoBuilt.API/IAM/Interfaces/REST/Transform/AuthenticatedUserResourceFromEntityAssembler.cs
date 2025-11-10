using IoBuilt.API.IAM.Domain.Model.Aggregates;
using IoBuilt.API.IAM.Interfaces.REST.Resources;

namespace IoBuilt.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Email, user.Role, token);
    }
}
