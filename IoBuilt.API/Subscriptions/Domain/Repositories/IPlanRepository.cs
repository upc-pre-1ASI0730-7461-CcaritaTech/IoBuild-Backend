using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;

namespace IoBuilt.API.Subscriptions.Domain.Repositories;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> ListAsync();
    Task<Plan?> FindByIdAsync(int id);
    Task<Plan?> FindByNameAsync(string name);
    Task AddAsync(Plan entity);
    void Update(Plan entity);
    void Remove(Plan entity);
    Task SaveChangesAsync();
}

