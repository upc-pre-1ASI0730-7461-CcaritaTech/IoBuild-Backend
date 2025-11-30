namespace IoBuilt.API.Analytics.Domain.Model.Queries;

/// <summary>
/// Query record for retrieving historical time-series data for a specific metric.
/// </summary>
/// <param name="ProjectId">The unique identifier of the project.</param>
/// <param name="DataType">The type of data to retrieve (e.g., "temperature", "energy", "water").</param>
/// <param name="StartDate">The start date of the data range.</param>
/// <param name="EndDate">The end date of the data range.</param>
public record GetHistoricalDataQuery(int ProjectId, string DataType, DateTime StartDate, DateTime EndDate);
