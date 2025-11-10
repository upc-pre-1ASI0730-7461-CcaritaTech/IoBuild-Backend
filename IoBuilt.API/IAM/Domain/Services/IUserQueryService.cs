using IoBuilt.API.IAM.Domain.Model.Aggregates;
using IoBuilt.API.IAM.Domain.Model.Queries;

namespace IoBuilt.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
}