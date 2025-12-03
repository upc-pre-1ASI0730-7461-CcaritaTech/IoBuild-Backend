namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

/// <summary>
/// Represents the data transfer object for creating a new unit via REST API.
/// 
/// This record encapsulates the information required to create a unit and is used
/// for deserialization of client requests into a strongly-typed format.
/// </summary>
/// <param name="ProjectId">The identifier of the project that this unit will belong to.</param>
/// <param name="UnitNumber">The unit number or identifier within the project.</param>
/// <param name="OwnerId">The identifier of the client who will own this unit.</param>
public record CreateUnitResource(
    int ProjectId,
    string UnitNumber,
    int OwnerId
);
