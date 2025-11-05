using IoBuilt.API.Devices.Domain.Model.Aggregates;

namespace IoBuilt.API.Devices.Domain.Repositories;

public interface IDeviceRepository
{
    Task<IEnumerable<Device>> ListAsync();
    Task<Device?> FindByIdAsync(int id);
    Task AddAsync(Device device);
    void Update(Device device);
    void Remove(Device device);
    Task SaveChangesAsync();
}