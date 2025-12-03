using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Application.Internal.CommandServices;

/// <summary>
/// Implements the command service for managing project operations.
/// 
/// This class handles the business logic for creating, updating, and deleting projects.
/// It enforces domain rules and constraints, such as preventing duplicate project names
/// and ensuring project existence before modifications.
/// </summary>
public class ProjectCommandService(
    IProjectRepository projectRepository,
    IUnitOfWork unitOfWork) : IProjectCommandService
{
    /// <summary>
    /// Asynchronously creates a new project based on the provided command.
    /// </summary>
    /// <param name="command">The command containing the project creation details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the newly created project, or null if the operation failed.</returns>
    /// <exception cref="Exception">Thrown if a project with the same name already exists.</exception>
    public async Task<Project?> Handle(CreateProjectCommand command)
    {
        var project = await projectRepository.FindByNameAsync(command.Name);
        if (project is not null) throw new Exception("Project already exists.");

        project = new Project(command);
        try
        {
            await projectRepository.AddAsync(project);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
        return project;
    }

    /// <summary>
    /// Asynchronously updates an existing project based on the provided command.
    /// </summary>
    /// <param name="command">The command containing the updated project information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the updated project, or null if the operation failed.</returns>
    /// <exception cref="Exception">Thrown if the project to update is not found, or if another
    /// project with the same name already exists.</exception>
    public async Task<Project?> Handle(UpdateProjectCommand command)
    {
        var project = await projectRepository.FindByIdAsync(command.Id);
        if (project is null) throw new Exception("Project not found.");

        // Check if another project with the same name exists (excluding current project)
        var existingProject = await projectRepository.FindByNameAsync(command.Name);
        if (existingProject is not null && existingProject.Id != command.Id) 
            throw new Exception("A project with the same name already exists.");

        project.Update(command);
        try
        {
            projectRepository.Update(project);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
        return project;
    }

    /// <summary>
    /// Asynchronously deletes an existing project based on the provided command.
    /// </summary>
    /// <param name="command">The command containing the project identifier to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result is true
    /// if the deletion was successful; otherwise, false.</returns>
    /// <exception cref="Exception">Thrown if the project to delete is not found.</exception>
    public async Task<bool> Handle(DeleteProjectCommand command)
    {
        var project = await projectRepository.FindByIdAsync(command.Id);
        if (project is null) throw new Exception("Project not found.");

        try
        {
            projectRepository.Remove(project);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}