using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using IoBuilt.API.Profiles.Interfaces.REST.Resources;

namespace IoBuilt.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(
            entity.Id, 
            entity.UserId, 
            entity.PhotoUrl, 
            entity.Name, 
            entity.Username, 
            entity.Address, 
            entity.Age, 
            entity.PhoneNumber);
    }
}
