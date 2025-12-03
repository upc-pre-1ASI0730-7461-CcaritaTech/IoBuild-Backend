namespace IoBuilt.API.Projects.Domain.Model.Queries;

/// <summary>
/// Represents a query to retrieve a specific project by its unique identifier.
/// 
/// This query encapsulates the request to fetch a project using its ID.
/// It follows the CQRS pattern and is used to execute query operations on the Project aggregate.
/// </summary>
/// <param name="ProjectId">The unique identifier of the project to retrieve.</param>
public record GetProjectByIdQuery(int ProjectId);