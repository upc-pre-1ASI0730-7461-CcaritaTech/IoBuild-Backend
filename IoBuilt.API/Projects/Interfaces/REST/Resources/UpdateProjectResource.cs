namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

/// <summary>
/// Represents the data transfer object for updating an existing project via REST API.
/// 
/// This record encapsulates the information required to update a project and is used
/// for deserialization of client update requests into a strongly-typed format.
/// </summary>
/// <param name="Name">The updated name of the project.</param>
/// <param name="Description">The updated description of the project.</param>
/// <param name="Location">The updated geographic location of the project.</param>
/// <param name="TotalUnits">The updated total number of units in the project.</param>
/// <param name="OccupiedUnits">The updated number of occupied units in the project.</param>
/// <param name="Status">The updated status of the project as a string.</param>
/// <param name="BuilderId">The updated identifier of the builder who owns this project.</param>
/// <param name="ImageUrl">The updated URL of the project's image.</param>
public record UpdateProjectResource(string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, string Status, int BuilderId, string ImageUrl);
