namespace IoBuilt.API.Analytics.Domain.Model.Queries;

/// <summary>
/// Query record for retrieving comprehensive dashboard analytics for a builder user.
/// </summary>
/// <param name="BuilderId">The unique identifier of the builder.</param>
public record GetBuilderDashboardQuery(int BuilderId);
