using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository implementation for <see cref="Plan"/> using Entity Framework Core.
/// Encapsulates data access for Plan aggregates via the injected <see cref="AppDbContext"/>.
/// </summary>
/// <param name="context">EF Core database context.</param>
public class PlanRepository(AppDbContext context) : IPlanRepository
{
    /// <summary>
    /// Return all plans stored in the database.
    /// Delegates to EF Core to materialize the list of <see cref="Plan"/> aggregates.
    /// </summary>
    /// <returns>An enumerable of <see cref="Plan"/>.</returns>
    public async Task<IEnumerable<Plan>> ListAsync()
    {
        return await context.Set<Plan>().ToListAsync();
    }

    /// <summary>
    /// Find a plan by its identifier.
    /// </summary>
    /// <param name="id">The plan identifier.</param>
    /// <returns>The <see cref="Plan"/> if found; otherwise, null.</returns>
    public async Task<Plan?> FindByIdAsync(int id)
    {
        return await context.Set<Plan>().FindAsync(id);
    }

    /// <summary>
    /// Find a plan by its name (case-insensitive).
    /// </summary>
    /// <param name="name">The plan name to search for.</param>
    /// <returns>The matching <see cref="Plan"/> if found; otherwise, null.</returns>
    public async Task<Plan?> FindByNameAsync(string name)
    {
        return await context.Set<Plan>()
            .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
    }

    /// <summary>
    /// Add a new <see cref="Plan"/> to the context. Changes are not saved until <see cref="SaveChangesAsync"/> is called.
    /// </summary>
    /// <param name="entity">The Plan entity to add.</param>
    /// <returns>A task representing the asynchronous add operation.</returns>
    public async Task AddAsync(Plan entity)
    {
        await context.Set<Plan>().AddAsync(entity);
    }

    /// <summary>
    /// Mark an existing <see cref="Plan"/> as modified in the context.
    /// </summary>
    /// <param name="entity">The Plan entity to update.</param>
    public void Update(Plan entity)
    {
        context.Set<Plan>().Update(entity);
    }

    /// <summary>
    /// Remove a <see cref="Plan"/> from the context.
    /// </summary>
    /// <param name="entity">The Plan entity to remove.</param>
    public void Remove(Plan entity)
    {
        context.Set<Plan>().Remove(entity);
    }

    /// <summary>
    /// Persist pending changes to the database.
    /// </summary>
    /// <returns>A task representing the asynchronous save operation.</returns>
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
