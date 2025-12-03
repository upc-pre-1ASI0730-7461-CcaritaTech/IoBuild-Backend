using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;

namespace IoBuilt.API.Projects.Application.Internal.QueryServices;

/// <summary>
/// Implements the query service for retrieving unit information.
/// 
/// This class handles the business logic for querying units from the persistence layer.
/// It provides methods to retrieve all units or a specific unit by identifier.
/// </summary>
public class UnitQueryService(IUnitRepository unitRepository) : IUnitQueryService
{
    /// <summary>
    /// Asynchronously retrieves all units from the system.
    /// </summary>
    /// <param name="query">The query object requesting all units.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of all units in the system.</returns>
    public async Task<IEnumerable<Unit>> Handle(GetAllUnitsQuery query)
    {
        return await unitRepository.ListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves a specific unit by its identifier.
    /// </summary>
    /// <param name="query">The query object containing the unit identifier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the unit with the specified identifier, or null if no such unit exists.</returns>
    public async Task<Unit?> Handle(GetUnitByIdQuery query)
    {
        return await unitRepository.FindByIdAsync(query.UnitId);
    }
}
