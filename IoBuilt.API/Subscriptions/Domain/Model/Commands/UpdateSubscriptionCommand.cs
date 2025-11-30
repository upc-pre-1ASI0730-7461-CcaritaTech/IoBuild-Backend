namespace IoBuilt.API.Subscriptions.Domain.Model.Commands;

public record UpdateSubscriptionCommand(
    int Id,
    int? PlanId,
    string? Status,
    DateTime? StartDate,
    DateTime? EndDate);

