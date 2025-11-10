using IoBuilt.API.IAM.Domain.Model.Aggregates;
using IoBuilt.API.IAM.Domain.Model.Queries;
using IoBuilt.API.IAM.Domain.Repositories;
using IoBuilt.API.IAM.Domain.Services;

namespace IoBuilt.API.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
}