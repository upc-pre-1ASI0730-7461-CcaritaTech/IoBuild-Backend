using IoBuilt.API.Profiles.Domain.Model.Queries;
using IoBuilt.API.Profiles.Domain.Services;
using IoBuilt.API.Profiles.Interfaces.ACL;
using IoBuilt.API.Profiles.Interfaces.REST.Resources;
using IoBuilt.API.Profiles.Interfaces.REST.Transform;

namespace IoBuilt.API.Profiles.Application.ACL;

/// <summary>
/// Facade for the profiles context
/// </summary>
/// <param name="profileQueryService">
/// The profile query service
/// </param>
public class ProfilesContextFacade(
    IProfileQueryService profileQueryService
) : IProfilesContextFacade
{
    // inheritedDoc
    public async Task<ProfileResource?> FetchProfileByUserId(int userId)
    {
        var getProfileByUserIdQuery = new GetProfileByUserIdQuery(userId);
        var profile = await profileQueryService.Handle(getProfileByUserIdQuery);
        return profile == null ? null : ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
    }
}
