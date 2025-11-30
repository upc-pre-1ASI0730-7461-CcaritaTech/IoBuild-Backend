using IoBuilt.API.Profiles.Domain.Model.Commands;
using IoBuilt.API.Profiles.Interfaces.REST.Resources;

namespace IoBuilt.API.Profiles.Interfaces.REST.Transform;

public static class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommandFromResource(UpdateProfileResource resource, int profileId)
    {
        return new UpdateProfileCommand(
            profileId,
            resource.PhotoUrl,
            resource.Name,
            resource.Username,
            resource.Address,
            resource.Age,
            resource.PhoneNumber);
    }
}

