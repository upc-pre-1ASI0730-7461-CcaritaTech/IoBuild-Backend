using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Domain.Model.ValueObjects;
using IoBuilt.API.Clients.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Clients.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository(AppDbContext context) : BaseRepository<Client>(context), IClientRepository
{
    public async Task<IEnumerable<Client>> FindByProjectIdAsync(int projectId)
    {
        return await Context.Set<Client>().Where(c => c.ProjectId == projectId).ToListAsync();
    }

    public async Task<IEnumerable<Client>> FindByAccountStatementAsync(EAccountStatement accountStatement)
    {
        return await Context.Set<Client>().Where(c => c.AccountStatement == accountStatement).ToListAsync();
    }

    public async Task<Client?> FindByEmailAsync(string email)
    {
        return await Context.Set<Client>().Where(c => c.Email == email).FirstOrDefaultAsync();
    }
}

