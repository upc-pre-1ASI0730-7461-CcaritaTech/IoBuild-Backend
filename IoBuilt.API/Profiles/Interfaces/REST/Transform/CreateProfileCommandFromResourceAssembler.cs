using IoBuilt.API.Profiles.Domain.Model.Commands;
using IoBuilt.API.Profiles.Interfaces.REST.Resources;

namespace IoBuilt.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.UserId,
            resource.PhotoUrl,
            resource.Name,
            resource.Username,
            resource.Address,
            resource.Age,
            resource.PhoneNumber
        );
    }
}
