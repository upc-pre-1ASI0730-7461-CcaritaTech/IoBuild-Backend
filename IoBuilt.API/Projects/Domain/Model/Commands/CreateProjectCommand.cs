namespace IoBuilt.API.Projects.Domain.Model.Commands;

/// <summary>
/// Represents a command to create a new project.
/// 
/// This command encapsulates the information required to create a new project in the system.
/// It follows the CQRS pattern and is used to execute create operations on the Project aggregate.
/// </summary>
/// <param name="Name">The name of the project.</param>
/// <param name="Description">The description of the project.</param>
/// <param name="Location">The geographic location of the project.</param>
/// <param name="TotalUnits">The total number of units in the project.</param>
/// <param name="BuilderId">The identifier of the builder who owns this project.</param>
/// <param name="ImageUrl">The URL of the project's image.</param>
public record CreateProjectCommand(string Name, string Description, string Location, int TotalUnits, int BuilderId, string ImageUrl);
