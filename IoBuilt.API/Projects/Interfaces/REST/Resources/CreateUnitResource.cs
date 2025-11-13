namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

public record CreateUnitResource(
    int ProjectId,
    string UnitNumber,
    int OwnerId
);
