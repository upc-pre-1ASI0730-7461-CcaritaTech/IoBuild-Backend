using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

/// <summary>
/// Provides transformation methods to convert CreateProjectResource objects into CreateProjectCommand objects.
/// 
/// This assembler implements the object mapper pattern to convert data transfer objects
/// from REST API requests into domain command objects for processing.
/// </summary>
public static class CreateProjectCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a CreateProjectResource to a CreateProjectCommand.
    /// </summary>
    /// <param name="resource">The project creation resource to convert.</param>
    /// <returns>A CreateProjectCommand containing the project creation details.</returns>
    public static CreateProjectCommand ToCommandFromResource(CreateProjectResource resource)
    {
        return new CreateProjectCommand(resource.Name, resource.Description, resource.Location,
            resource.TotalUnits, resource.BuilderId, resource.ImageUrl);
    }
}