namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a single time-series data point.
/// </summary>
/// <param name="Timestamp">The timestamp when this data point was recorded.</param>
/// <param name="Value">The measured value at this timestamp.</param>
/// <param name="Type">The type/category of data.</param>
public record HistoricalDataPointResource(
    DateTime Timestamp,
    double Value,
    string Type
);
