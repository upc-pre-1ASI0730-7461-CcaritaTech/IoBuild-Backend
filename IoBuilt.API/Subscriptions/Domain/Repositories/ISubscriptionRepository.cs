using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;

namespace IoBuilt.API.Subscriptions.Domain.Repositories;

public interface ISubscriptionRepository
{
    Task<IEnumerable<Subscription>> ListAsync();
    Task<Subscription?> FindByIdAsync(int id);
    Task<Subscription?> FindByBuilderIdAsync(int builderId);
    Task AddAsync(Subscription entity);
    void Update(Subscription entity);
    void Remove(Subscription entity);
    Task SaveChangesAsync();
}
