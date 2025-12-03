namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

/// <summary>
/// Represents the data transfer object for a unit resource in REST API responses.
/// 
/// This record encapsulates all unit information that is returned to API consumers
/// and is used for serialization of unit entities to JSON format.
/// </summary>
/// <param name="Id">The unique identifier of the unit.</param>
/// <param name="ProjectId">The identifier of the project that this unit belongs to.</param>
/// <param name="UnitNumber">The unit number or identifier within the project.</param>
/// <param name="OwnerId">The identifier of the client who owns this unit.</param>
public record UnitResource(
    int Id,
    int ProjectId,
    string UnitNumber,
    int OwnerId
);
