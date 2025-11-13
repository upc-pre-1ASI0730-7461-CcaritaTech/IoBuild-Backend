using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Model.ValueObjects;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

public static class UpdateProjectCommandFromResourceAssembler
{
    public static UpdateProjectCommand ToCommandFromResource(UpdateProjectResource resource, int id)
    {
        var status = Enum.Parse<EProjectStatus>(resource.Status, ignoreCase: true);
        return new UpdateProjectCommand(id, resource.Name, resource.Description, resource.Location, 
            resource.TotalUnits, resource.OccupiedUnits, status, resource.BuilderId, resource.ImageUrl);
    }
}
