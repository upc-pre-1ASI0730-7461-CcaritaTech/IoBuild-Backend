using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly DbContext _context;

    public SubscriptionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Subscription>> ListAsync()
        => await _context.Set<Subscription>().ToListAsync();

    public async Task<Subscription?> FindByIdAsync(int id)
        => await _context.Set<Subscription>().FindAsync(id);

    public async Task<Subscription?> FindByBuilderIdAsync(int builderId)
        => await _context.Set<Subscription>().FirstOrDefaultAsync(s => s.BuilderId == builderId);

    public async Task AddAsync(Subscription entity)
        => await _context.Set<Subscription>().AddAsync(entity);

    public void Update(Subscription entity)
        => _context.Set<Subscription>().Update(entity);

    public void Remove(Subscription entity)
        => _context.Set<Subscription>().Remove(entity);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}