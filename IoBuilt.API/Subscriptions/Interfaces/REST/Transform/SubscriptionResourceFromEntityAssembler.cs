using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

namespace IoBuilt.API.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResource(Subscription entity) => new(
        entity.Id,
        entity.BuilderId,
        entity.Plan,
        entity.Status,
        entity.StartDate,
        entity.EndDate,
        entity.Price,
        entity.Features
    );
}