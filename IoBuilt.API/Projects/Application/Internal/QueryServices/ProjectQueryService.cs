using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;

namespace IoBuilt.API.Projects.Application.Internal.QueryServices;

public class ProjectQueryService(IProjectRepository projectRepository) : IProjectQueryService
{
    public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query)
    {
        return await projectRepository.ListAsync();
    }

    public async Task<Project?> Handle(GetProjectByIdQuery query)
    {
        return await projectRepository.FindByIdAsync(query.ProjectId);
    }
}