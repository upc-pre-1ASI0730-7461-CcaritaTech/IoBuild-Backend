using IoBuilt.API.Projects.Domain.Model.ValueObjects;

namespace IoBuilt.API.Projects.Domain.Model.Commands;

/// <summary>
/// Represents a command to update an existing project.
/// 
/// This command encapsulates the information required to update a project in the system.
/// It follows the CQRS pattern and is used to execute update operations on the Project aggregate.
/// </summary>
/// <param name="Id">The unique identifier of the project to be updated.</param>
/// <param name="Name">The updated name of the project.</param>
/// <param name="Description">The updated description of the project.</param>
/// <param name="Location">The updated geographic location of the project.</param>
/// <param name="TotalUnits">The updated total number of units in the project.</param>
/// <param name="OccupiedUnits">The updated number of occupied units in the project.</param>
/// <param name="Status">The updated status of the project.</param>
/// <param name="BuilderId">The updated identifier of the builder who owns this project.</param>
/// <param name="ImageUrl">The updated URL of the project's image.</param>
public record UpdateProjectCommand(int Id, string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, EProjectStatus Status, int BuilderId, string ImageUrl);
