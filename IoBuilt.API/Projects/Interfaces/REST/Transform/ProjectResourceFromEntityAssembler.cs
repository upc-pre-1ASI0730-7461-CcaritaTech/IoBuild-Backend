using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

/// <summary>
/// Provides transformation methods to convert Project entities into ProjectResource objects.
/// 
/// This assembler implements the object mapper pattern to convert domain entities
/// into data transfer objects for REST API responses.
/// </summary>
public static class ProjectResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a Project entity to a ProjectResource.
    /// </summary>
    /// <param name="entity">The project entity to convert.</param>
    /// <returns>A ProjectResource containing the project information.</returns>
    public static ProjectResource ToResourceFromEntity(Project entity)
    {
        return new ProjectResource(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Location,
            entity.TotalUnits,
            entity.OccupiedUnits,
            entity.Status.ToString(),
            entity.BuilderId,
            entity.CreatedDate,
            entity.ImageUrl);
    }
}