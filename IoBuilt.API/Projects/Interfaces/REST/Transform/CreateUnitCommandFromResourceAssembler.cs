using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

public static class CreateUnitCommandFromResourceAssembler
{
    public static CreateUnitCommand ToCommandFromResource(CreateUnitResource resource)
    {
        return new CreateUnitCommand(
            resource.ProjectId,
            resource.UnitNumber,
            resource.OwnerId
        );
    }
}
