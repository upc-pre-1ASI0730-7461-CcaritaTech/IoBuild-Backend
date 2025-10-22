using IoBuilt.API.Monitoring.Domain.Model.Aggregates;
using IoBuilt.API.Monitoring.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class DeviceRepository(AppDbContext context) : BaseRepository<Device>(context), IDeviceRepository
{
    public async Task<IEnumerable<Device>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<Device>().Where(d => d.ProjectId == projectId).ToListAsync();
    }

    public async Task<IEnumerable<Device>> FindByStatusAsync(string status)
    {
        return await Context.Set<Device>().Where(d => d.Status == status).ToListAsync();
    }

    public async Task<IEnumerable<Device>> FindByTypeAsync(string type)
    {
        return await Context.Set<Device>().Where(d => d.Type == type).ToListAsync();
    }
}