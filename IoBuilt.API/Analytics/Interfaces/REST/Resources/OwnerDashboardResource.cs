namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

public record OwnerDashboardResource(
    int TotalDevices,
    int OnlineDevices,
    int OfflineDevices,
    int AlertsCount,
    int MyUnitsCount,
    double EnergyThisMonth,
    double TemperatureAvg,
    double WaterUsageThisMonth,
    IEnumerable<HistoricalDataPointResource> TemperatureHistory,
    IEnumerable<HistoricalDataPointResource> EnergyHistory,
    IEnumerable<HistoricalDataPointResource> DailyEnergyConsumption,
    IEnumerable<HistoricalDataPointResource> WaterUsageWeekly,
    IEnumerable<DeviceHealthStatusResource> DeviceHealthStatus,
    IEnumerable<UnitDetailResource> MyUnitsDetails
);
