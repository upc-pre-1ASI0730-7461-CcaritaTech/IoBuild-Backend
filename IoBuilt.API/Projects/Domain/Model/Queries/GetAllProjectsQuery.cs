namespace IoBuilt.API.Projects.Domain.Model.Queries;

/// <summary>
/// Represents a query to retrieve all projects from the system.
/// 
/// This query encapsulates the request to fetch all projects without any filtering criteria.
/// It follows the CQRS pattern and is used to execute query operations on the Project aggregate.
/// </summary>
public record GetAllProjectsQuery();