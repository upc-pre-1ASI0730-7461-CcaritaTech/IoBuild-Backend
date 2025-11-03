using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Interfaces.REST.Resources;

namespace IoBuilt.API.Projects.Interfaces.REST.Transform;

public static class CreateProjectCommandFromResourceAssembler
{
    public static CreateProjectCommand ToCommandFromResource(CreateProjectResource resource)
    {
        return new CreateProjectCommand(resource.Id, resource.Name, resource.Description, resource.Location,
            resource.TotalUnits, resource.OccupiedUnits, resource.Status, resource.BuilderId, resource.CreatedDate,
            resource.ImageUrl);
    }
}