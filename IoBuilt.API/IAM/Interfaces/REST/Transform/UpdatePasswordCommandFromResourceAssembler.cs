using IoBuilt.API.IAM.Domain.Model.Commands;
using IoBuilt.API.IAM.Interfaces.REST.Resources;

namespace IoBuilt.API.IAM.Interfaces.REST.Transform;

public class UpdatePasswordCommandFromResourceAssembler
{
    public static UpdatePasswordCommand ToCommandFromResource(int userId, UpdatePasswordResource resource)
        => new(userId, resource.CurrentPassword, resource.NewPassword);
}