using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

/// <summary>
/// Provides transformation methods to convert Unit entities into UnitResource objects.
/// 
/// This assembler implements the object mapper pattern to convert domain entities
/// into data transfer objects for REST API responses.
/// </summary>
public static class UnitResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a Unit entity to a UnitResource.
    /// </summary>
    /// <param name="entity">The unit entity to convert.</param>
    /// <returns>A UnitResource containing the unit information.</returns>
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
