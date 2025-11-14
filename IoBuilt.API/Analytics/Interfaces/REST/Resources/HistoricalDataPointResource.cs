namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

public record HistoricalDataPointResource(
    DateTime Timestamp,
    double Value,
    string Type
);
