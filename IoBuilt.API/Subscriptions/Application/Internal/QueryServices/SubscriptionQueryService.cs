using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;

namespace IoBuilt.API.Subscriptions.Application.Internal.QueryServices;

/// <summary>
/// Application query service for Subscription.
/// Provides read-only operations to retrieve Subscription aggregates via the injected <see cref="ISubscriptionRepository"/>.
/// </summary>
public class SubscriptionQueryService : ISubscriptionQueryService
{
    private readonly ISubscriptionRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionQueryService"/> class.
    /// </summary>
    /// <param name="repository">Repository for accessing Subscription aggregates.</param>
    public SubscriptionQueryService(ISubscriptionRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles queries to return all subscriptions.
    /// </summary>
    /// <param name="query">Query object representing the request to get all subscriptions.</param>
    /// <returns>An enumerable of <see cref="Subscription"/> aggregates.</returns>
    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
        => await _repository.ListAsync();

    /// <summary>
    /// Handles queries to retrieve a subscription by its identifier.
    /// </summary>
    /// <param name="query">Query containing the subscription Id to retrieve.</param>
    /// <returns>The <see cref="Subscription"/> if found; otherwise, null.</returns>
    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
        => await _repository.FindByIdAsync(query.Id);
}
