using IoBuilt.API.Analytics.Domain.Model.Aggregates;
using IoBuilt.API.Analytics.Domain.Model.Entities;
using IoBuilt.API.Analytics.Domain.Model.Queries;

namespace IoBuilt.API.Analytics.Domain.Services;

public interface IAnalyticsQueryService
{
    Task<BuilderMetrics?> Handle(GetBuilderDashboardQuery query);
    Task<OwnerMetrics?> Handle(GetOwnerDashboardQuery query);
    Task<IEnumerable<HistoricalDataPoint>> Handle(GetHistoricalDataQuery query);
}
