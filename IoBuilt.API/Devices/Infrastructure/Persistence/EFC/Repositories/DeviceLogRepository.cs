using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Devices.Infrastructure.Persistence.EFC.Repositories;

public class DeviceLogRepository : BaseRepository<DeviceLog>, IDeviceLogRepository
{
    public DeviceLogRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DeviceLog>> FindByDeviceIdAsync(int deviceId)
    {
        return await Context.Set<DeviceLog>()
            .Where(dl => dl.DeviceId == deviceId)
            .OrderByDescending(dl => dl.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<DeviceLog>> FindByDeviceIdAndTypeAsync(int deviceId, string type)
    {
        return await Context.Set<DeviceLog>()
            .Where(dl => dl.DeviceId == deviceId && dl.Type == type)
            .OrderByDescending(dl => dl.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<DeviceLog>> FindByDeviceIdAndDateRangeAsync(int deviceId, DateTime startDate, DateTime endDate)
    {
        return await Context.Set<DeviceLog>()
            .Where(dl => dl.DeviceId == deviceId && dl.Timestamp >= startDate && dl.Timestamp <= endDate)
            .OrderByDescending(dl => dl.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<DeviceLog>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<DeviceLog>()
            .Include(dl => dl.DeviceId)
            .Where(dl => Context.Set<Device>().Any(d => d.Id == dl.DeviceId && d.ProjectId == projectId))
            .OrderByDescending(dl => dl.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<DeviceLog>> FindByProjectIdAndTypeAsync(int projectId, string type)
    {
        return await Context.Set<DeviceLog>()
            .Where(dl => Context.Set<Device>().Any(d => d.Id == dl.DeviceId && d.ProjectId == projectId) && dl.Type == type)
            .OrderByDescending(dl => dl.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<DeviceLog>> FindByProjectIdAndDateRangeAsync(int projectId, DateTime startDate, DateTime endDate)
    {
        return await Context.Set<DeviceLog>()
            .Where(dl => Context.Set<Device>().Any(d => d.Id == dl.DeviceId && d.ProjectId == projectId) 
                         && dl.Timestamp >= startDate && dl.Timestamp <= endDate)
            .OrderByDescending(dl => dl.Timestamp)
            .ToListAsync();
    }
}
