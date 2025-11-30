using IoBuilt.API.Analytics.Domain.Model.Aggregates;
using IoBuilt.API.Analytics.Domain.Model.Entities;
using IoBuilt.API.Analytics.Domain.Model.Queries;

namespace IoBuilt.API.Analytics.Domain.Services;

/// <summary>
/// Domain service interface for handling analytics queries.
/// Provides methods to retrieve aggregated metrics and historical data for dashboards.
/// </summary>
public interface IAnalyticsQueryService
{
    /// <summary>
    /// Handles a query to retrieve builder dashboard metrics.
    /// Aggregates data from all projects managed by the builder.
    /// </summary>
    /// <param name="query">The builder dashboard query containing the builder ID.</param>
    /// <returns>Builder metrics if found; otherwise null.</returns>
    Task<BuilderMetrics?> Handle(GetBuilderDashboardQuery query);
    
    /// <summary>
    /// Handles a query to retrieve owner dashboard metrics.
    /// Aggregates data from all units owned by the owner.
    /// </summary>
    /// <param name="query">The owner dashboard query containing the owner ID.</param>
    /// <returns>Owner metrics if found; otherwise null.</returns>
    Task<OwnerMetrics?> Handle(GetOwnerDashboardQuery query);
    
    /// <summary>
    /// Handles a query to retrieve historical data points for a specific metric.
    /// </summary>
    /// <param name="query">The historical data query with project, data type, and date range.</param>
    /// <returns>Collection of historical data points matching the query criteria.</returns>
    Task<IEnumerable<HistoricalDataPoint>> Handle(GetHistoricalDataQuery query);
}
