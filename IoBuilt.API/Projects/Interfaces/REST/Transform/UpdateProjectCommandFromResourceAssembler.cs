using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

public static class UpdateProjectCommandFromResourceAssembler
{
    public static UpdateProjectCommand ToCommandFromResource(UpdateProjectResource resource, int id)
    {
        return new UpdateProjectCommand(id, resource.Name, resource.Description, resource.Location, 
            resource.TotalUnits, resource.OccupiedUnits, resource.Status, resource.BuilderId, resource.ImageUrl);
    }
}
