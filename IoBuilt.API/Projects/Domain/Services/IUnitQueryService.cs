using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;

namespace IoBuilt.API.Projects.Domain.Services;

public interface IUnitQueryService
{
    Task<IEnumerable<Unit>> Handle(GetAllUnitsQuery query);
    Task<Unit?> Handle(GetUnitByIdQuery query);
}
