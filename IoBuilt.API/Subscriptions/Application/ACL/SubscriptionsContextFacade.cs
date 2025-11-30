using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Services;
using IoBuilt.API.Subscriptions.Interfaces.ACL;

namespace IoBuilt.API.Subscriptions.Application.ACL;

/// <summary>
/// Implementation of the Anti-Corruption Layer Facade for Subscriptions Bounded Context
/// This class acts as a bridge between bounded contexts, exposing only necessary information
/// </summary>
public class SubscriptionsContextFacade : ISubscriptionsContextFacade
{
    private readonly IPlanQueryService _planQueryService;

    public SubscriptionsContextFacade(IPlanQueryService planQueryService)
    {
        _planQueryService = planQueryService;
    }

    public async Task<int?> FetchPlanIdByNameAsync(string planName)
    {
        var plan = await _planQueryService.Handle(new GetPlanByNameQuery(planName));
        return plan?.Id;
    }

    public async Task<bool> ValidatePlanExistsAsync(int planId)
    {
        var plan = await _planQueryService.Handle(new GetPlanByIdQuery(planId));
        return plan != null;
    }

    public async Task<(string Name, decimal Price, int MaxDevices, int MaxAdministrators)?> FetchPlanDetailsAsync(int planId)
    {
        var plan = await _planQueryService.Handle(new GetPlanByIdQuery(planId));
        
        if (plan == null)
            return null;
        
        return (plan.Name, plan.Price, plan.MaxDevices, plan.MaxAdministrators);
    }
}

