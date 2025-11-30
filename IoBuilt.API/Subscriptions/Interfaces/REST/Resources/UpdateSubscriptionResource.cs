namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

public record UpdateSubscriptionResource(
    int? PlanId,
    string? Status,
    DateTime? StartDate,
    DateTime? EndDate);
