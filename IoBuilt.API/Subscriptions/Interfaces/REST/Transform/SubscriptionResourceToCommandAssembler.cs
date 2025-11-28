using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

namespace IoBuilt.API.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceToCommandAssembler
{
    public static CreateSubscriptionCommand ToCommand(CreateSubscriptionResource resource) =>
        new(resource.BuilderId, resource.Plan, resource.Status, resource.StartDate, resource.EndDate, resource.Price, resource.Features);

    public static UpdateSubscriptionCommand ToCommand(int id, UpdateSubscriptionResource resource) =>
        new(id, resource.Plan, resource.Status, resource.StartDate, resource.EndDate, resource.Price, resource.Features);
}