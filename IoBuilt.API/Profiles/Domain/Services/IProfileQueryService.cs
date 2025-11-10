using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using IoBuilt.API.Profiles.Domain.Model.Queries;

namespace IoBuilt.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
    Task<Profile?> Handle(GetProfileByUserIdQuery query);
}
