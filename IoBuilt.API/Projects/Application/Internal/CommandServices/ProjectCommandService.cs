using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Application.Internal.CommandServices;

public class ProjectCommandService(
    IProjectRepository projectRepository,
    IUnitOfWork unitOfWork) : IProjectCommandService
{
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