namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

/// <summary>
/// Represents the data transfer object for a project resource in REST API responses.
/// 
/// This record encapsulates all project information that is returned to API consumers
/// and is used for serialization of project entities to JSON format.
/// </summary>
/// <param name="Id">The unique identifier of the project.</param>
/// <param name="Name">The name of the project.</param>
/// <param name="Description">The description of the project.</param>
/// <param name="Location">The geographic location of the project.</param>
/// <param name="TotalUnits">The total number of units in the project.</param>
/// <param name="OccupiedUnits">The number of currently occupied units in the project.</param>
/// <param name="Status">The current status of the project as a string.</param>
/// <param name="BuilderId">The identifier of the builder who owns this project.</param>
/// <param name="CreatedDate">The date and time when the project was created.</param>
/// <param name="ImageUrl">The URL of the project's image.</param>
public record ProjectResource(
    int Id,
    string Name,
    string Description,
    string Location,
    int TotalUnits,
    int OccupiedUnits,
    string Status,
    int BuilderId,
    DateTime CreatedDate,
    string ImageUrl);