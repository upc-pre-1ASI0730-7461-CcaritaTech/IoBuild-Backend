using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

/// <summary>
/// Provides transformation methods to convert CreateUnitResource objects into CreateUnitCommand objects.
/// 
/// This assembler implements the object mapper pattern to convert data transfer objects
/// from REST API requests into domain command objects for processing.
/// </summary>
public static class CreateUnitCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a CreateUnitResource to a CreateUnitCommand.
    /// </summary>
    /// <param name="resource">The unit creation resource to convert.</param>
    /// <returns>A CreateUnitCommand containing the unit creation details.</returns>
    public static CreateUnitCommand ToCommandFromResource(CreateUnitResource resource)
    {
        return new CreateUnitCommand(
            resource.ProjectId,
            resource.UnitNumber,
            resource.OwnerId
        );
    }
}
