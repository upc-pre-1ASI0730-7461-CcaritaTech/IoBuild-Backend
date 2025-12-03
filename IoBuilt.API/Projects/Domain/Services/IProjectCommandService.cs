using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;

namespace IoBuilt.API.Projects.Domain.Services;

/// <summary>
/// Defines the contract for handling command operations on projects.
/// 
/// This interface specifies the methods for executing domain commands that modify
/// the state of projects, including creation, updates, and deletion.
/// </summary>
public interface IProjectCommandService
{
    /// <summary>
    /// Asynchronously handles a command to create a new project.
    /// </summary>
    /// <param name="command">The command containing the project creation details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the newly created project, or null if the creation failed.</returns>
    Task<Project?> Handle(CreateProjectCommand command);

    /// <summary>
    /// Asynchronously handles a command to update an existing project.
    /// </summary>
    /// <param name="command">The command containing the updated project information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the updated project, or null if the update failed.</returns>
    Task<Project?> Handle(UpdateProjectCommand command);

    /// <summary>
    /// Asynchronously handles a command to delete an existing project.
    /// </summary>
    /// <param name="command">The command containing the project identifier to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result is true
    /// if the deletion was successful; otherwise, false.</returns>
    Task<bool> Handle(DeleteProjectCommand command);
}