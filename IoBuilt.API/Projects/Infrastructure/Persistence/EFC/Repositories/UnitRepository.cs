using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Repositories;

public class UnitRepository : BaseRepository<Unit>, IUnitRepository
{
    public UnitRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Unit>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<Unit>()
            .Where(u => u.ProjectId == projectId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Unit>> FindByOwnerIdAsync(int ownerId)
    {
        return await Context.Set<Unit>()
            .Where(u => u.OwnerId == ownerId)
            .ToListAsync();
    }

    public async Task<Unit?> FindByProjectIdAndUnitNumberAsync(int projectId, string unitNumber)
    {
        return await Context.Set<Unit>()
            .FirstOrDefaultAsync(u => u.ProjectId == projectId && u.UnitNumber == unitNumber);
    }
}
