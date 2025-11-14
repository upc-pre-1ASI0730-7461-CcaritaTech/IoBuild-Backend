using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

public static class UnitResourceFromEntityAssembler
{
    public static UnitResource ToResourceFromEntity(Unit entity)
    {
        return new UnitResource(
            entity.Id,
            entity.ProjectId,
            entity.UnitNumber,
            entity.OwnerId
        );
    }
}
