using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository(AppDbContext context) : IPlanRepository
{
    public async Task<IEnumerable<Plan>> ListAsync()
    {
        return await context.Set<Plan>().ToListAsync();
    }

    public async Task<Plan?> FindByIdAsync(int id)
    {
        return await context.Set<Plan>().FindAsync(id);
    }

    public async Task<Plan?> FindByNameAsync(string name)
    {
        return await context.Set<Plan>()
            .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
    }

    public async Task AddAsync(Plan entity)
    {
        await context.Set<Plan>().AddAsync(entity);
    }

    public void Update(Plan entity)
    {
        context.Set<Plan>().Update(entity);
    }

    public void Remove(Plan entity)
    {
        context.Set<Plan>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}

