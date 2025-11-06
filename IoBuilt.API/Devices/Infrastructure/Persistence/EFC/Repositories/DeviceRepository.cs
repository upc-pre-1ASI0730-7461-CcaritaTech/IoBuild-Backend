using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Devices.Infrastructure.Persistence.EFC.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly DbContext _context;

    public DeviceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Device>> ListAsync()
        => await _context.Set<Device>().ToListAsync();

    public async Task<Device?> FindByIdAsync(int id)
        => await _context.Set<Device>().FindAsync(id);

    public async Task AddAsync(Device device)
        => await _context.Set<Device>().AddAsync(device);

    public void Update(Device device)
        => _context.Set<Device>().Update(device);

    public void Remove(Device device)
        => _context.Set<Device>().Remove(device);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}