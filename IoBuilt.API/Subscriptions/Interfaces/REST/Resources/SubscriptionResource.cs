namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(
    int Id,
    int BuilderId,
    PlanResource Plan,
    string Status,
    DateTime? StartDate,
    DateTime? EndDate);
