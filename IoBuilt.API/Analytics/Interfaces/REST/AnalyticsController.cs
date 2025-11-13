using IoBuilt.API.Analytics.Domain.Model.Queries;
using IoBuilt.API.Analytics.Domain.Services;
using IoBuilt.API.Analytics.Interfaces.REST.Resources;
using IoBuilt.API.Analytics.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IoBuilt.API.Analytics.Interfaces.REST;

[ApiController]
[Route("api/v1/analytics")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsQueryService _analyticsQueryService;

    public AnalyticsController(IAnalyticsQueryService analyticsQueryService)
    {
        _analyticsQueryService = analyticsQueryService;
    }

    /// <summary>
    /// Get dashboard analytics metrics by user ID and role
    /// </summary>
    /// <param name="userId">The user ID (builder or owner)</param>
    /// <param name="role">The user role: 'builder' or 'owner'</param>
    /// <returns>Dashboard metrics based on the user role</returns>
    [HttpGet("metrics/{userId}")]
    [SwaggerOperation(
        Summary = "Get dashboard metrics",
        Description = "Returns analytics dashboard metrics for a user based on their role (builder or owner)",
        OperationId = "GetDashboardMetrics"
    )]
    [SwaggerResponse(200, "Metrics retrieved successfully")]
    [SwaggerResponse(400, "Invalid role parameter")]
    [SwaggerResponse(404, "User not found or has no projects/units")]
    public async Task<IActionResult> GetDashboardMetrics(int userId, [FromQuery] string role)
    {
        if (string.IsNullOrWhiteSpace(role))
            return BadRequest("Role parameter is required");

        role = role.ToLower();
        
        if (role == "builder")
        {
            var query = new GetBuilderDashboardQuery(userId);
            var dashboard = await _analyticsQueryService.Handle(query);
            
            if (dashboard is null)
                return NotFound("Builder not found or has no projects");

            var resource = BuilderDashboardResourceFromEntityAssembler.ToResourceFromEntity(dashboard);
            return Ok(resource);
        }
        else if (role == "owner")
        {
            var query = new GetOwnerDashboardQuery(userId);
            var dashboard = await _analyticsQueryService.Handle(query);
            
            if (dashboard is null)
                return NotFound("Owner not found or has no units");

            var resource = OwnerDashboardResourceFromEntityAssembler.ToResourceFromEntity(dashboard);
            return Ok(resource);
        }
        else
        {
            return BadRequest("Invalid role. Must be 'builder' or 'owner'");
        }
    }

    /// <summary>
    /// Get analytical insights for specific metrics
    /// </summary>
    /// <param name="projectId">The project ID (optional, can be passed via query)</param>
    /// <param name="metric">Type of metric/insight (e.g., 'energy', 'temperature', 'water')</param>
    /// <param name="startDate">Start date for data range</param>
    /// <param name="endDate">End date for data range</param>
    /// <returns>Historical data points for the specified metric</returns>
    [HttpGet("insights")]
    [SwaggerOperation(
        Summary = "Get analytical insights",
        Description = "Returns analytical insights and historical data for specific metrics and projects",
        OperationId = "GetAnalyticalInsights"
    )]
    [SwaggerResponse(200, "Insights retrieved successfully", typeof(IEnumerable<HistoricalDataPointResource>))]
    [SwaggerResponse(400, "Invalid parameters")]
    public async Task<IActionResult> GetAnalyticalInsights(
        [FromQuery] int? projectId,
        [FromQuery] string metric,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        if (!projectId.HasValue)
            return BadRequest("ProjectId is required");

        if (string.IsNullOrWhiteSpace(metric))
            return BadRequest("Metric parameter is required");

        var start = startDate ?? DateTime.UtcNow.AddDays(-30);
        var end = endDate ?? DateTime.UtcNow;

        if (start > end)
            return BadRequest("Start date must be before end date");

        var query = new GetHistoricalDataQuery(projectId.Value, metric, start, end);
        var historicalData = await _analyticsQueryService.Handle(query);

        var resources = historicalData.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // Legacy endpoints - mantener por compatibilidad temporal
    
    /// <summary>
    /// [DEPRECATED] Get builder dashboard analytics - Use GET /api/v1/analytics/metrics/{userId}?role=builder instead
    /// </summary>
    [HttpGet("builder/{builderId}/dashboard")]
    [SwaggerOperation(
        Summary = "[DEPRECATED] Get builder dashboard",
        Description = "This endpoint is deprecated. Use GET /api/v1/analytics/metrics/{userId}?role=builder instead",
        OperationId = "GetBuilderDashboard_Deprecated"
    )]
    [SwaggerResponse(200, "Dashboard data retrieved successfully", typeof(BuilderDashboardResource))]
    [SwaggerResponse(404, "Builder not found or has no projects")]
    public async Task<IActionResult> GetBuilderDashboard(int builderId)
    {
        var query = new GetBuilderDashboardQuery(builderId);
        var dashboard = await _analyticsQueryService.Handle(query);
        
        if (dashboard is null)
            return NotFound("Builder not found or has no projects");

        var resource = BuilderDashboardResourceFromEntityAssembler.ToResourceFromEntity(dashboard);
        return Ok(resource);
    }

    /// <summary>
    /// [DEPRECATED] Get owner dashboard analytics - Use GET /api/v1/analytics/metrics/{userId}?role=owner instead
    /// </summary>
    [HttpGet("owner/{ownerId}/dashboard")]
    [SwaggerOperation(
        Summary = "[DEPRECATED] Get owner dashboard",
        Description = "This endpoint is deprecated. Use GET /api/v1/analytics/metrics/{userId}?role=owner instead",
        OperationId = "GetOwnerDashboard_Deprecated"
    )]
    [SwaggerResponse(200, "Dashboard data retrieved successfully", typeof(OwnerDashboardResource))]
    [SwaggerResponse(404, "Owner not found or has no units")]
    public async Task<IActionResult> GetOwnerDashboard(int ownerId)
    {
        var query = new GetOwnerDashboardQuery(ownerId);
        var dashboard = await _analyticsQueryService.Handle(query);
        
        if (dashboard is null)
            return NotFound("Owner not found or has no units");

        var resource = OwnerDashboardResourceFromEntityAssembler.ToResourceFromEntity(dashboard);
        return Ok(resource);
    }

    /// <summary>
    /// [DEPRECATED] Get historical data - Use GET /api/v1/analytics/insights instead
    /// </summary>
    [HttpGet("projects/{projectId}/historical")]
    [SwaggerOperation(
        Summary = "[DEPRECATED] Get historical data",
        Description = "This endpoint is deprecated. Use GET /api/v1/analytics/insights?projectId={id}&metric={type} instead",
        OperationId = "GetHistoricalData_Deprecated"
    )]
    [SwaggerResponse(200, "Historical data retrieved successfully", typeof(IEnumerable<HistoricalDataPointResource>))]
    [SwaggerResponse(400, "Invalid parameters")]
    public async Task<IActionResult> GetHistoricalData(
        int projectId,
        [FromQuery] string dataType,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(dataType))
            return BadRequest("Data type is required");

        if (startDate > endDate)
            return BadRequest("Start date must be before end date");

        var query = new GetHistoricalDataQuery(projectId, dataType, startDate, endDate);
        var historicalData = await _analyticsQueryService.Handle(query);

        var resources = historicalData.Select(HistoricalDataPointResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
