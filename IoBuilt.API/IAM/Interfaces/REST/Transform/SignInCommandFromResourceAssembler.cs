using IoBuilt.API.IAM.Domain.Model.Commands;
using IoBuilt.API.IAM.Interfaces.REST.Resources;

namespace IoBuilt.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}
