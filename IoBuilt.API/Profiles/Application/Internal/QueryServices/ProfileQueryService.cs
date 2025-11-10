using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using IoBuilt.API.Profiles.Domain.Model.Queries;
using IoBuilt.API.Profiles.Domain.Repositories;
using IoBuilt.API.Profiles.Domain.Services;

namespace IoBuilt.API.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
    }

    public async Task<Profile?> Handle(GetProfileByUserIdQuery query)
    {
        return await profileRepository.FindByUserIdAsync(query.UserId);
    }
}
