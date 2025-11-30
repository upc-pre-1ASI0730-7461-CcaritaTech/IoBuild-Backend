using IoBuilt.API.Analytics.Domain.Model.Aggregates;
using IoBuilt.API.Analytics.Interfaces.REST.Resources;

namespace IoBuilt.API.Analytics.Interfaces.REST.Transform;

/// <summary>
/// Assembler for transforming BuilderMetrics domain aggregate to BuilderDashboardResource.
/// </summary>
public static class BuilderDashboardResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a BuilderMetrics domain aggregate to BuilderDashboardResource.
    /// </summary>
    /// <param name="entity">The BuilderMetrics aggregate to transform.</param>
    /// <returns>The transformed BuilderDashboardResource.</returns>
    public static BuilderDashboardResource ToResourceFromEntity(BuilderMetrics entity)
    {
        return new BuilderDashboardResource(
            entity.TotalDevices,
            entity.OnlineDevices,
            entity.OfflineDevices,
            entity.AlertsCount,
            entity.ActiveProjectsCount,
            entity.TotalUnits,
            entity.OccupiedUnits,
            entity.OccupancyRate,
            entity.EnergyEfficiencyAvg,
            entity.TemperatureHistory.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity),
            entity.EnergyHistory.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity),
            entity.HourlyEnergyData.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity),
            entity.MonthlyOccupancy.Select(m => new MonthlyOccupancyDataResource(m.Month, m.OccupancyRate, m.Year)),
            entity.DevicesByType,
            entity.ProjectsOverview.Select(p => new ProjectOverviewResource(
                p.Id, p.Name, p.Location, p.Status, p.TotalUnits, p.OccupiedUnits, p.OccupancyRate, p.DeviceCount))
        );
    }
}
