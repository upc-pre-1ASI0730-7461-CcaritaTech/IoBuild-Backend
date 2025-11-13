using IoBuilt.API.Analytics.Domain.Model.Aggregates;
using IoBuilt.API.Analytics.Interfaces.REST.Resources;

namespace IoBuilt.API.Analytics.Interfaces.REST.Transform;

public static class OwnerDashboardResourceFromEntityAssembler
{
    public static OwnerDashboardResource ToResourceFromEntity(OwnerMetrics entity)
    {
        return new OwnerDashboardResource(
            entity.TotalDevices,
            entity.OnlineDevices,
            entity.OfflineDevices,
            entity.AlertsCount,
            entity.MyUnitsCount,
            entity.EnergyThisMonth,
            entity.TemperatureAvg,
            entity.WaterUsageThisMonth,
            entity.TemperatureHistory.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity),
            entity.EnergyHistory.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity),
            entity.DailyEnergyConsumption.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity),
            entity.WaterUsageWeekly.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity),
            entity.DeviceHealthStatus.Select(d => new DeviceHealthStatusResource(
                d.DeviceId, d.DeviceName, d.Type, d.Status, d.HealthPercentage)),
            entity.MyUnitsDetails.Select(u => new UnitDetailResource(
                u.UnitId, u.UnitNumber, u.ProjectName, u.ActiveDevices, u.ConnectionStatus))
        );
    }
}
