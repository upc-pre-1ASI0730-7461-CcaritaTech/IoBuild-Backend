using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

namespace IoBuilt.API.Subscriptions.Interfaces.REST.Transform;

public static class PlanResourceToCommandAssembler
{
    public static CreatePlanCommand ToCommand(CreatePlanResource resource)
    {
        return new CreatePlanCommand(
            resource.Name,
            resource.Price,
            resource.Description,
            resource.Features,
            resource.MaxDevices,
            resource.MaxAdministrators,
            resource.SupportLevel,
            resource.HasAPI,
            resource.HasAnalytics
        );
    }

    public static UpdatePlanCommand ToCommand(int id, UpdatePlanResource resource)
    {
        return new UpdatePlanCommand(
            id,
            resource.Name,
            resource.Price,
            resource.Description,
            resource.Features,
            resource.MaxDevices,
            resource.MaxAdministrators,
            resource.SupportLevel,
            resource.HasAPI,
            resource.HasAnalytics
        );
    }
}

