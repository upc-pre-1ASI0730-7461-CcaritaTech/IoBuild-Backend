namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

public record CreateSubscriptionResource(
    int BuilderId,
    int PlanId,
    string Status,
    DateTime? StartDate,
    DateTime? EndDate);
