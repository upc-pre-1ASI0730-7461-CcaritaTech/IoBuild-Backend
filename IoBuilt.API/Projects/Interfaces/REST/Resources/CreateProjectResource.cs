namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

/// <summary>
/// Represents the data transfer object for creating a new project via REST API.
/// 
/// This record encapsulates the information required to create a project and is used
/// for deserialization of client requests into a strongly-typed format.
/// </summary>
/// <param name="Name">The name of the project to create.</param>
/// <param name="Description">The description of the project.</param>
/// <param name="Location">The geographic location of the project.</param>
/// <param name="TotalUnits">The total number of units in the project.</param>
/// <param name="BuilderId">The identifier of the builder who will own this project.</param>
/// <param name="ImageUrl">The URL of the project's image.</param>
public record CreateProjectResource(string Name, string Description, string Location, int TotalUnits, int BuilderId, string ImageUrl);
