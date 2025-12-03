namespace IoBuilt.API.Projects.Domain.Model.Queries;

/// <summary>
/// Represents a query to retrieve a specific unit by its unique identifier.
/// 
/// This query encapsulates the request to fetch a unit using its ID.
/// It follows the CQRS pattern and is used to execute query operations on the Unit aggregate.
/// </summary>
/// <param name="UnitId">The unique identifier of the unit to retrieve.</param>
public record GetUnitByIdQuery(int UnitId);
