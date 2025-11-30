using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;

namespace IoBuilt.API.Subscriptions.Application.Internal.QueryServices;

public class PlanQueryService(IPlanRepository repository) : IPlanQueryService
{
    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<Plan?> Handle(GetPlanByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
    }

    public async Task<Plan?> Handle(GetPlanByNameQuery query)
    {
        return await repository.FindByNameAsync(query.Name);
    }
}

