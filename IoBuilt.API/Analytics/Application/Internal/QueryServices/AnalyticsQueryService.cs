using IoBuilt.API.Analytics.Domain.Model.Aggregates;
using IoBuilt.API.Analytics.Domain.Model.Entities;
using IoBuilt.API.Analytics.Domain.Model.Queries;
using IoBuilt.API.Analytics.Domain.Services;
using IoBuilt.API.Analytics.Interfaces.ACL;

namespace IoBuilt.API.Analytics.Application.Internal.QueryServices;

/// <summary>
/// Application service implementing analytics query handling.
/// Orchestrates data retrieval from multiple bounded contexts via ACL facades
/// to build comprehensive analytical insights and metrics.
/// </summary>
public class AnalyticsQueryService : IAnalyticsQueryService
{
    private readonly IDevicesContextFacade _devicesContextFacade;
    private readonly IProjectsContextFacade _projectsContextFacade;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnalyticsQueryService"/> class.
    /// </summary>
    /// <param name="devicesContextFacade">Facade for accessing Devices bounded context.</param>
    /// <param name="projectsContextFacade">Facade for accessing Projects bounded context.</param>
    public AnalyticsQueryService(IDevicesContextFacade devicesContextFacade, IProjectsContextFacade projectsContextFacade)
    {
        _devicesContextFacade = devicesContextFacade;
        _projectsContextFacade = projectsContextFacade;
    }

    /// <summary>
    /// Handles builder dashboard query by aggregating metrics across all builder's projects.
    /// Retrieves device counts, occupancy data, energy trends, and project overviews.
    /// </summary>
    /// <param name="query">Query containing the builder ID.</param>
    /// <returns>
    /// BuilderMetrics aggregate containing comprehensive analytics, or null if builder has no projects.
    /// </returns>
    public async Task<BuilderMetrics?> Handle(GetBuilderDashboardQuery query)
    {
        var projectIds = await _projectsContextFacade.GetProjectIdsByBuilderIdAsync(query.BuilderId);
        var projectIdsList = projectIds.ToList();
        
        if (!projectIdsList.Any())
            return null;

        int totalDevices = 0;
        int onlineDevices = 0;
        int offlineDevices = 0;
        var temperatureLogs = new List<HistoricalDataPoint>();
        var energyLogs = new List<HistoricalDataPoint>();
        var hourlyEnergyLogs = new List<HistoricalDataPoint>();
        var devicesByType = new Dictionary<string, int>();
        var projectsOverview = new List<ProjectOverview>();
        int totalUnits = 0;
        int occupiedUnits = 0;

        foreach (var projectId in projectIdsList)
        {
            // Get project details
            var project = await _projectsContextFacade.GetProjectByIdAsync(projectId);
            if (project != null)
            {
                totalUnits += project.TotalUnits;
                occupiedUnits += project.OccupiedUnits;
                
                var projectDeviceCount = await _devicesContextFacade.CountDevicesByProjectIdAsync(projectId);
                projectsOverview.Add(new ProjectOverview
                {
                    Id = project.Id,
                    Name = project.Name,
                    Location = project.Location,
                    Status = project.Status.ToString(),
                    TotalUnits = project.TotalUnits,
                    OccupiedUnits = project.OccupiedUnits,
                    OccupancyRate = project.TotalUnits > 0 ? (double)project.OccupiedUnits / project.TotalUnits * 100 : 0,
                    DeviceCount = projectDeviceCount
                });
            }

            // Count devices
            totalDevices += await _devicesContextFacade.CountDevicesByProjectIdAsync(projectId);
            onlineDevices += await _devicesContextFacade.CountDevicesByProjectIdAndStatusAsync(projectId, "Online");
            offlineDevices += await _devicesContextFacade.CountDevicesByProjectIdAndStatusAsync(projectId, "Offline");

            // Get devices by type for this project
            var devices = await _devicesContextFacade.GetDevicesByProjectIdAsync(projectId);
            foreach (var device in devices)
            {
                if (devicesByType.ContainsKey(device.Type))
                    devicesByType[device.Type]++;
                else
                    devicesByType[device.Type] = 1;
            }

            // Get temperature daily averages for last 30 days
            var tempLogs = await _devicesContextFacade.GetDeviceLogsByProjectIdAndDateRangeAsync(
                projectId,
                DateTime.UtcNow.AddDays(-30),
                DateTime.UtcNow);
            
            temperatureLogs.AddRange(tempLogs
                .Where(log => log.Type.Contains("temperature"))
                .Select(log => new HistoricalDataPoint
                {
                    Timestamp = log.Timestamp,
                    Value = log.Value,
                    Type = log.Type
                }));

            // Get energy daily totals for last 30 days
            var energyLogsData = await _devicesContextFacade.GetDeviceLogsByProjectIdAndDateRangeAsync(
                projectId,
                DateTime.UtcNow.AddDays(-30),
                DateTime.UtcNow);

            energyLogs.AddRange(energyLogsData
                .Where(log => log.Type.Contains("energy") && log.Type.Contains("daily"))
                .Select(log => new HistoricalDataPoint
                {
                    Timestamp = log.Timestamp,
                    Value = log.Value,
                    Type = log.Type
                }));

            // Get hourly energy data for last 24 hours
            var hourlyLogs = await _devicesContextFacade.GetDeviceLogsByProjectIdAndDateRangeAsync(
                projectId,
                DateTime.UtcNow.AddHours(-24),
                DateTime.UtcNow);

            hourlyEnergyLogs.AddRange(hourlyLogs
                .Where(log => log.Type == "energy" && !log.Type.Contains("daily"))
                .Select(log => new HistoricalDataPoint
                {
                    Timestamp = log.Timestamp,
                    Value = log.Value,
                    Type = log.Type
                }));
        }

        // Calculate energy efficiency average (from energy logs)
        double energyEfficiencyAvg = energyLogs.Any() ? energyLogs.Average(e => e.Value) : 0;

        // Generate monthly occupancy data for last 6 months
        var monthlyOccupancy = new List<MonthlyOccupancyData>();
        for (int i = 5; i >= 0; i--)
        {
            var month = DateTime.UtcNow.AddMonths(-i);
            // Simulate occupancy growth trend
            double occupancyRate = totalUnits > 0 ? ((double)occupiedUnits / totalUnits * 100) - (i * 2) : 0;
            occupancyRate = Math.Max(occupancyRate, 50); // Minimum 50%
            
            monthlyOccupancy.Add(new MonthlyOccupancyData
            {
                Month = month.ToString("MMM"),
                Year = month.Year,
                OccupancyRate = Math.Round(occupancyRate, 1)
            });
        }

        return new BuilderMetrics
        {
            TotalDevices = totalDevices,
            OnlineDevices = onlineDevices,
            OfflineDevices = offlineDevices,
            AlertsCount = offlineDevices,
            ActiveProjectsCount = projectIdsList.Count,
            TotalUnits = totalUnits,
            OccupiedUnits = occupiedUnits,
            OccupancyRate = totalUnits > 0 ? Math.Round((double)occupiedUnits / totalUnits * 100, 1) : 0,
            EnergyEfficiencyAvg = Math.Round(energyEfficiencyAvg, 2),
            TemperatureHistory = temperatureLogs.OrderBy(t => t.Timestamp).ToList(),
            EnergyHistory = energyLogs.OrderBy(e => e.Timestamp).ToList(),
            HourlyEnergyData = hourlyEnergyLogs.OrderBy(e => e.Timestamp).ToList(),
            MonthlyOccupancy = monthlyOccupancy,
            DevicesByType = devicesByType,
            ProjectsOverview = projectsOverview
        };
    }

    /// <summary>
    /// Handles owner dashboard query by aggregating metrics across all owner's units.
    /// Retrieves device health, energy consumption, water usage, temperature data, and unit details.
    /// </summary>
    /// <param name="query">Query containing the owner ID.</param>
    /// <returns>
    /// OwnerMetrics aggregate containing comprehensive analytics, or null if owner has no units.
    /// </returns>
    public async Task<OwnerMetrics?> Handle(GetOwnerDashboardQuery query)
    {
        var projectIds = await _projectsContextFacade.GetProjectIdsByOwnerIdAsync(query.OwnerId);
        var projectIdsList = projectIds.ToList();
        
        if (!projectIdsList.Any())
            return null;

        int totalDevices = 0;
        int onlineDevices = 0;
        int offlineDevices = 0;
        var temperatureLogs = new List<HistoricalDataPoint>();
        var energyLogs = new List<HistoricalDataPoint>();
        var dailyEnergyLogs = new List<HistoricalDataPoint>();
        var waterLogs = new List<HistoricalDataPoint>();
        var deviceHealthList = new List<DeviceHealthStatus>();
        var myUnitsDetails = new List<UnitDetail>();

        // Get owner's units
        var ownerUnits = await _projectsContextFacade.GetUnitsByOwnerIdAsync(query.OwnerId);
        int myUnitsCount = ownerUnits.Count();

        foreach (var projectId in projectIdsList)
        {
            // Get devices
            var devices = await _devicesContextFacade.GetDevicesByProjectIdAsync(projectId);
            totalDevices += devices.Count();
            onlineDevices += devices.Count(d => d.Status == "Online");
            offlineDevices += devices.Count(d => d.Status == "Offline");

            // Get project details for unit details
            var project = await _projectsContextFacade.GetProjectByIdAsync(projectId);

            // Build unit details
            foreach (var unit in ownerUnits.Where(u => u.ProjectId == projectId))
            {
                var unitsDevices = devices.Count(d => d.Status == "Online");
                myUnitsDetails.Add(new UnitDetail
                {
                    UnitId = unit.Id,
                    UnitNumber = unit.UnitNumber,
                    ProjectName = project?.Name ?? "Unknown Project",
                    ActiveDevices = unitsDevices,
                    ConnectionStatus = unitsDevices > 0 ? "Connected" : "Disconnected"
                });
            }

            // Device health status
            foreach (var device in devices)
            {
                double health = device.Status == "Online" ? 95.0 : 40.0;
                deviceHealthList.Add(new DeviceHealthStatus
                {
                    DeviceId = device.Id,
                    DeviceName = device.Name,
                    Type = device.Type,
                    Status = device.Status,
                    HealthPercentage = health
                });
            }

            // Get temperature data for last 30 days
            var tempLogs = await _devicesContextFacade.GetDeviceLogsByProjectIdAndDateRangeAsync(
                projectId,
                DateTime.UtcNow.AddDays(-30),
                DateTime.UtcNow);
            
            temperatureLogs.AddRange(tempLogs
                .Where(log => log.Type.Contains("temperature"))
                .Select(log => new HistoricalDataPoint
                {
                    Timestamp = log.Timestamp,
                    Value = log.Value,
                    Type = log.Type
                }));

            // Get energy data for last 30 days
            var energyLogsData = await _devicesContextFacade.GetDeviceLogsByProjectIdAndDateRangeAsync(
                projectId,
                DateTime.UtcNow.AddDays(-30),
                DateTime.UtcNow);

            energyLogs.AddRange(energyLogsData
                .Where(log => log.Type.Contains("energy"))
                .Select(log => new HistoricalDataPoint
                {
                    Timestamp = log.Timestamp,
                    Value = log.Value,
                    Type = log.Type
                }));

            // Daily energy consumption (last 30 days)
            dailyEnergyLogs.AddRange(energyLogsData
                .Where(log => log.Type.Contains("energy") && log.Type.Contains("daily"))
                .Select(log => new HistoricalDataPoint
                {
                    Timestamp = log.Timestamp,
                    Value = log.Value,
                    Type = log.Type
                }));

            // Get water usage data for last 7 days
            var waterLogsData = await _devicesContextFacade.GetDeviceLogsByProjectIdAndDateRangeAsync(
                projectId,
                DateTime.UtcNow.AddDays(-7),
                DateTime.UtcNow);

            waterLogs.AddRange(waterLogsData
                .Where(log => log.Type.Contains("water"))
                .Select(log => new HistoricalDataPoint
                {
                    Timestamp = log.Timestamp,
                    Value = log.Value,
                    Type = log.Type
                }));
        }

        // Calculate averages
        double temperatureAvg = temperatureLogs.Any() ? temperatureLogs.Average(t => t.Value) : 0;
        
        // Energy this month (sum of last 30 days)
        double energyThisMonth = dailyEnergyLogs.Where(e => e.Timestamp >= DateTime.UtcNow.AddDays(-30)).Sum(e => e.Value);
        
        // Water usage this month
        double waterUsageThisMonth = waterLogs.Sum(w => w.Value);

        return new OwnerMetrics
        {
            TotalDevices = totalDevices,
            OnlineDevices = onlineDevices,
            OfflineDevices = offlineDevices,
            AlertsCount = offlineDevices,
            MyUnitsCount = myUnitsCount,
            EnergyThisMonth = Math.Round(energyThisMonth, 2),
            TemperatureAvg = Math.Round(temperatureAvg, 1),
            WaterUsageThisMonth = Math.Round(waterUsageThisMonth, 2),
            TemperatureHistory = temperatureLogs.OrderBy(t => t.Timestamp).ToList(),
            EnergyHistory = energyLogs.OrderBy(e => e.Timestamp).ToList(),
            DailyEnergyConsumption = dailyEnergyLogs.OrderBy(e => e.Timestamp).ToList(),
            WaterUsageWeekly = waterLogs.OrderBy(w => w.Timestamp).ToList(),
            DeviceHealthStatus = deviceHealthList,
            MyUnitsDetails = myUnitsDetails
        };
    }

    /// <summary>
    /// Handles historical data query for a specific metric type within a date range.
    /// </summary>
    /// <param name="query">Query containing project ID, data type, and date range.</param>
    /// <returns>Collection of historical data points matching the query criteria.</returns>
    public async Task<IEnumerable<HistoricalDataPoint>> Handle(GetHistoricalDataQuery query)
    {
        var logs = await _devicesContextFacade.GetDeviceLogsByProjectIdAndDateRangeAsync(
            query.ProjectId,
            query.StartDate,
            query.EndDate);

        return logs
            .Where(log => log.Type == query.DataType)
            .Select(log => new HistoricalDataPoint
            {
                Timestamp = log.Timestamp,
                Value = log.Value,
                Type = log.Type
            })
            .OrderBy(h => h.Timestamp);
    }
}
