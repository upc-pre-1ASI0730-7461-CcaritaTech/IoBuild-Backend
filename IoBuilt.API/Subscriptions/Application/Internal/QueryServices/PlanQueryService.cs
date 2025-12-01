using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;

namespace IoBuilt.API.Subscriptions.Application.Internal.QueryServices;

/// <summary>
/// Application query service for Plan.
/// Provides read-only operations to retrieve Plan aggregates using the injected <see cref="IPlanRepository"/>.
/// </summary>
public class PlanQueryService(IPlanRepository repository) : IPlanQueryService
{
    /// <summary>
    /// Handles queries to return all plans.
    /// Delegates to the repository to list all stored Plan aggregates.
    /// </summary>
    /// <param name="query">Query object representing the request to get all plans.</param>
    /// <returns>An enumerable of <see cref="Plan"/> aggregates.</returns>
    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query)
    {
        return await repository.ListAsync();
    }

    /// <summary>
    /// Handles queries to retrieve a plan by its identifier.
    /// </summary>
    /// <param name="query">Query containing the plan Id to retrieve.</param>
    /// <returns>The <see cref="Plan"/> if found; otherwise, null.</returns>
    public async Task<Plan?> Handle(GetPlanByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
    }

    /// <summary>
    /// Handles queries to retrieve a plan by its name.
    /// </summary>
    /// <param name="query">Query containing the plan name to search for.</param>
    /// <returns>The <see cref="Plan"/> if a match is found; otherwise, null.</returns>
    public async Task<Plan?> Handle(GetPlanByNameQuery query)
    {
        return await repository.FindByNameAsync(query.Name);
    }
}
