using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

public static class ProjectResourceFromEntityAssembler
{
    public static ProjectResource ToResourceFromEntity(Project entity)
    {
        return new ProjectResource(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Location,
            entity.TotalUnits,
            entity.OccupiedUnits,
            entity.Status,
            entity.BuilderId,
            entity.CreatedDate,
            entity.ImageUrl);
    }
}