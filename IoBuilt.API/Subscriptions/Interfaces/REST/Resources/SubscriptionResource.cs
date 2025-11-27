namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(
    int Id,
    int BuilderId,
    string Plan,
    string Status,
    DateTime? StartDate,
    DateTime? EndDate,
    decimal Price,
    IEnumerable<string> Features);