using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;

namespace IoBuilt.API.Projects.Domain.Services;

public interface IProjectCommandService
{
    Task<Project?> Handle(CreateProjectCommand command);
    Task<Project?> Handle(UpdateProjectCommand command);
    Task<bool> Handle(DeleteProjectCommand command);
}