namespace IoBuilt.API.Analytics.Domain.Model.Queries;

/// <summary>
/// Query record for retrieving comprehensive dashboard analytics for an owner user.
/// </summary>
/// <param name="OwnerId">The unique identifier of the owner.</param>
public record GetOwnerDashboardQuery(int OwnerId);
