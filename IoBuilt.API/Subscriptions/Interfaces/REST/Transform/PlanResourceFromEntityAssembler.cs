using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;
namespace IoBuilt.API.Subscriptions.Interfaces.REST.Transform;
public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResource(Plan entity)
    {
        return new PlanResource(
            entity.Id,
            entity.Name,
            entity.Price,
            entity.Description,
            entity.Features,
            entity.MaxDevices,
            entity.MaxAdministrators,
            entity.SupportLevel,
            entity.HasAPI,
            entity.HasAnalytics
        );
    }
}
