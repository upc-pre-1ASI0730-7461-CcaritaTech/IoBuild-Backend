using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;

namespace IoBuilt.API.Projects.Domain.Services;

public interface IProjectQueryService
{
    Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query);
    Task<Project?> Handle(GetProjectByIdQuery query);
}