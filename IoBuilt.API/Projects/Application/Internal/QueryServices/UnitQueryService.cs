using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;

namespace IoBuilt.API.Projects.Application.Internal.QueryServices;

public class UnitQueryService(IUnitRepository unitRepository) : IUnitQueryService
{
    public async Task<IEnumerable<Unit>> Handle(GetAllUnitsQuery query)
    {
        return await unitRepository.ListAsync();
    }

    public async Task<Unit?> Handle(GetUnitByIdQuery query)
    {
        return await unitRepository.FindByIdAsync(query.UnitId);
    }
}
