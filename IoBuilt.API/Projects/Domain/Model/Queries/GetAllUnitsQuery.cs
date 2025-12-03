namespace IoBuilt.API.Projects.Domain.Model.Queries;

/// <summary>
/// Represents a query to retrieve all units from the system.
/// 
/// This query encapsulates the request to fetch all units without any filtering criteria.
/// It follows the CQRS pattern and is used to execute query operations on the Unit aggregate.
/// </summary>
public record GetAllUnitsQuery();
