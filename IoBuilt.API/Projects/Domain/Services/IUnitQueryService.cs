using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Queries;

namespace IoBuilt.API.Projects.Domain.Services;

/// <summary>
/// Defines the contract for handling query operations on units.
/// 
/// This interface specifies the methods for executing domain queries that retrieve
/// unit data without modifying the system state.
/// </summary>
public interface IUnitQueryService
{
    /// <summary>
    /// Asynchronously handles a query to retrieve all units.
    /// </summary>
    /// <param name="query">The query object requesting all units.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// a collection of all units in the system.</returns>
    Task<IEnumerable<Unit>> Handle(GetAllUnitsQuery query);

    /// <summary>
    /// Asynchronously handles a query to retrieve a specific unit by its identifier.
    /// </summary>
    /// <param name="query">The query object containing the unit identifier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the unit with the specified identifier, or null if no such unit exists.</returns>
    Task<Unit?> Handle(GetUnitByIdQuery query);
}
