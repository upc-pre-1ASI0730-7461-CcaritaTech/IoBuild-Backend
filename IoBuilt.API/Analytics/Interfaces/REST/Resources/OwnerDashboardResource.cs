namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

/// <summary>
/// Resource representing comprehensive dashboard metrics for property owner users.
/// Contains device health, energy consumption, water usage, and unit details.
/// </summary>
/// <param name="TotalDevices">Total number of devices across all owner's units.</param>
/// <param name="OnlineDevices">Count of devices currently online.</param>
/// <param name="OfflineDevices">Count of devices currently offline.</param>
/// <param name="AlertsCount">Total number of active alerts.</param>
/// <param name="MyUnitsCount">Number of units owned by this owner.</param>
/// <param name="EnergyThisMonth">Total energy consumption for the current month.</param>
/// <param name="TemperatureAvg">Average temperature across all owner's units.</param>
/// <param name="WaterUsageThisMonth">Total water usage for the current month.</param>
/// <param name="TemperatureHistory">Temperature data for the last 30 days.</param>
/// <param name="EnergyHistory">Energy consumption data for the last 30 days.</param>
/// <param name="DailyEnergyConsumption">Daily energy consumption for the last 30 days.</param>
/// <param name="WaterUsageWeekly">Water usage data for the last 7 days.</param>
/// <param name="DeviceHealthStatus">Health status of all devices across owner's units.</param>
/// <param name="MyUnitsDetails">Detailed information for each unit owned.</param>
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
