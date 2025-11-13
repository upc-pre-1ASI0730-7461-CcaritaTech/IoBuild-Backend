namespace IoBuilt.API.Projects.Domain.Model.Commands;

public record CreateUnitCommand(int ProjectId, string UnitNumber, int OwnerId);
