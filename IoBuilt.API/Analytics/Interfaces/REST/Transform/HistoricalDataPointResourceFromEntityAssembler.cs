using IoBuilt.API.Analytics.Domain.Model.Entities;
using IoBuilt.API.Analytics.Interfaces.REST.Resources;

namespace IoBuilt.API.Analytics.Interfaces.REST.Transform;

/// <summary>
/// Assembler for transforming HistoricalDataPoint domain entity to HistoricalDataPointResource.
/// </summary>
public static class HistoricalDataPointResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a HistoricalDataPoint domain entity to HistoricalDataPointResource.
    /// </summary>
    /// <param name="entity">The HistoricalDataPoint entity to transform.</param>
    /// <returns>The transformed HistoricalDataPointResource.</returns>
    public static HistoricalDataPointResource ToResourceFromEntity(HistoricalDataPoint entity)
    {
        return new HistoricalDataPointResource(
            entity.Timestamp,
            entity.Value,
            entity.Type
        );
    }
}
