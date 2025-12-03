using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Model.ValueObjects;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

/// <summary>
/// Provides transformation methods to convert UpdateProjectResource objects into UpdateProjectCommand objects.
/// 
/// This assembler implements the object mapper pattern to convert data transfer objects
/// from REST API requests into domain command objects for processing. It also handles
/// the conversion of the project status string to the appropriate enumeration value.
/// </summary>
public static class UpdateProjectCommandFromResourceAssembler
{
    /// <summary>
    /// Converts an UpdateProjectResource to an UpdateProjectCommand.
    /// </summary>
    /// <param name="resource">The project update resource to convert.</param>
    /// <param name="id">The unique identifier of the project being updated.</param>
    /// <returns>An UpdateProjectCommand containing the project update details with the
    /// project status converted from string to EProjectStatus enumeration.</returns>
    public static UpdateProjectCommand ToCommandFromResource(UpdateProjectResource resource, int id)
    {
        var status = Enum.Parse<EProjectStatus>(resource.Status, ignoreCase: true);
        return new UpdateProjectCommand(id, resource.Name, resource.Description, resource.Location, 
            resource.TotalUnits, resource.OccupiedUnits, status, resource.BuilderId, resource.ImageUrl);
    }
}
