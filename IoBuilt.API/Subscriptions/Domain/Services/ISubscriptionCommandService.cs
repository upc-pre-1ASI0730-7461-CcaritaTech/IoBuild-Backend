using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;

namespace IoBuilt.API.Subscriptions.Domain.Services;

public interface ISubscriptionCommandService
{
    Task<int> Handle(CreateSubscriptionCommand command);
    Task Handle(UpdateSubscriptionCommand command);
}
