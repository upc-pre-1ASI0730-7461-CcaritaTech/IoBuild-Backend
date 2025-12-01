using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository implementation for <see cref="Subscription"/> using Entity Framework Core.
/// Encapsulates data access for Subscription aggregates and includes related <see cref="Plan"/> data when returning subscriptions.
/// </summary>
public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly DbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionRepository"/> class.
    /// </summary>
    /// <param name="context">EF Core <see cref="AppDbContext"/> used to access the database.</param>
    public SubscriptionRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Return all subscriptions including their related plan information.
    /// </summary>
    /// <returns>An enumerable of <see cref="Subscription"/> aggregates with populated <see cref="Plan"/>.</returns>
    public async Task<IEnumerable<Subscription>> ListAsync()
        => await _context.Set<Subscription>().Include(s => s.Plan).ToListAsync();

    /// <summary>
    /// Find a subscription by its identifier, including the related plan.
    /// </summary>
    /// <param name="id">The subscription identifier.</param>
    /// <returns>The matching <see cref="Subscription"/> if found; otherwise, null.</returns>
    public async Task<Subscription?> FindByIdAsync(int id)
        => await _context.Set<Subscription>().Include(s => s.Plan).FirstOrDefaultAsync(s => s.Id == id);

    /// <summary>
    /// Find the first subscription associated with the specified builder identifier, including the related plan.
    /// </summary>
    /// <param name="builderId">The builder identifier to search subscriptions for.</param>
    /// <returns>The matching <see cref="Subscription"/> if found; otherwise, null.</returns>
    public async Task<Subscription?> FindByBuilderIdAsync(int builderId)
        => await _context.Set<Subscription>().Include(s => s.Plan).FirstOrDefaultAsync(s => s.BuilderId == builderId);

    /// <summary>
    /// Add a new <see cref="Subscription"/> to the context. Changes are not persisted until <see cref="SaveChangesAsync"/> is called.
    /// </summary>
    /// <param name="entity">The Subscription entity to add.</param>
    public async Task AddAsync(Subscription entity)
        => await _context.Set<Subscription>().AddAsync(entity);

    /// <summary>
    /// Mark an existing <see cref="Subscription"/> as modified in the context.
    /// </summary>
    /// <param name="entity">The Subscription entity to update.</param>
    public void Update(Subscription entity)
        => _context.Set<Subscription>().Update(entity);

    /// <summary>
    /// Remove a <see cref="Subscription"/> from the context.
    /// </summary>
    /// <param name="entity">The Subscription entity to remove.</param>
    public void Remove(Subscription entity)
        => _context.Set<Subscription>().Remove(entity);

    /// <summary>
    /// Persist pending changes to the database.
    /// </summary>
    /// <returns>A task representing the asynchronous save operation.</returns>
    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}