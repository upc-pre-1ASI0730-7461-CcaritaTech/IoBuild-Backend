namespace IoBuilt.API.Projects.Domain.Model.Commands;

/// <summary>
/// Represents a command to create a new unit within a project.
/// 
/// This command encapsulates the information required to create a new unit entity.
/// It follows the CQRS pattern and is used to execute create operations on the Unit aggregate.
/// </summary>
/// <param name="ProjectId">The identifier of the project that this unit belongs to.</param>
/// <param name="UnitNumber">The unit number or identifier within the project.</param>
/// <param name="OwnerId">The identifier of the client who owns this unit.</param>
public record CreateUnitCommand(int ProjectId, string UnitNumber, int OwnerId);
