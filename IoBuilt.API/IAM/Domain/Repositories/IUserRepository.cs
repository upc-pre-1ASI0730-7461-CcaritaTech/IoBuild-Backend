using IoBuilt.API.IAM.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
}