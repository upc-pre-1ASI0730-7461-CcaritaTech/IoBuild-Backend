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
}