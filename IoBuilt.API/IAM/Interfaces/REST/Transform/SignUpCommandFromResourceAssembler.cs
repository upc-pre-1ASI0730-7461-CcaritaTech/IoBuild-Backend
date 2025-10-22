using IoBuilt.API.IAM.Domain.Model.Commands;
using IoBuilt.API.IAM.Interfaces.REST.Resources;

namespace IoBuilt.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Email, resource.Password, resource.Role);
    }
}
