namespace IoBuilt.API.Projects.Domain.Model.Commands;

/// <summary>
/// Represents a command to delete an existing project.
/// 
/// This command encapsulates the information required to delete a project from the system.
/// It follows the CQRS pattern and is used to execute delete operations on the Project aggregate.
/// </summary>
/// <param name="Id">The unique identifier of the project to be deleted.</param>
public record DeleteProjectCommand(int Id);
