using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;

namespace IoBuilt.API.Subscriptions.Application.Internal.QueryServices;

public class SubscriptionQueryService : ISubscriptionQueryService
{
    private readonly ISubscriptionRepository _repository;

    public SubscriptionQueryService(ISubscriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
        => await _repository.ListAsync();

    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
        => await _repository.FindByIdAsync(query.Id);
    
}
