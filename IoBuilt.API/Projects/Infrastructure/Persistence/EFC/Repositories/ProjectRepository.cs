using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Repositories;

public class ProjectRepository(AppDbContext context) : BaseRepository<Project>(context), IProjectRepository
{
    public async Task<IEnumerable<Project>> FindByBuilderIdAsync(int builderId)
    {
        return await Context.Set<Project>().Where(p => p.BuilderId == builderId).ToListAsync();
    }

    public async Task<IEnumerable<Project>> FindByStatusAsync(string status)
    {
        return await Context.Set<Project>().Where(p => p.Status == status).ToListAsync();
    }
}