namespace IoBuilt.API.Analytics.Domain.Model.Queries;

public record GetHistoricalDataQuery(int ProjectId, string DataType, DateTime StartDate, DateTime EndDate);
