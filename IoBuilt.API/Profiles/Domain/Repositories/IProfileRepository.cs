using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindByUserIdAsync(int userId);
    Task<IEnumerable<Profile>> FindByUsernameAsync(string username);
}
