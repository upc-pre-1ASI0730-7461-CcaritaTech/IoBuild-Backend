using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

namespace IoBuilt.API.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceToCommandAssembler
{
    public static CreateSubscriptionCommand ToCommand(CreateSubscriptionResource resource) =>
        new(resource.BuilderId, resource.PlanId, resource.Status, resource.StartDate, resource.EndDate);

    public static UpdateSubscriptionCommand ToCommand(int id, UpdateSubscriptionResource resource) =>
        new(id, resource.PlanId, resource.Status, resource.StartDate, resource.EndDate);
}