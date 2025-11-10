using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using IoBuilt.API.Profiles.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public async Task<Profile?> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Profile>().FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<IEnumerable<Profile>> FindByUsernameAsync(string username)
    {
        return await Context.Set<Profile>().Where(p => p.Username.Contains(username)).ToListAsync();
    }
}
