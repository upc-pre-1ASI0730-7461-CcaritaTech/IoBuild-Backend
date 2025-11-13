using IoBuilt.API.Analytics.Domain.Model.Entities;
using IoBuilt.API.Analytics.Interfaces.REST.Resources;

namespace IoBuilt.API.Analytics.Interfaces.REST.Transform;

public static class HistoricalDataPointResourceFromEntityAssembler
{
    public static HistoricalDataPointResource ToResourceFromEntity(HistoricalDataPoint entity)
    {
        return new HistoricalDataPointResource(
            entity.Timestamp,
            entity.Value,
            entity.Type
        );
    }
}
