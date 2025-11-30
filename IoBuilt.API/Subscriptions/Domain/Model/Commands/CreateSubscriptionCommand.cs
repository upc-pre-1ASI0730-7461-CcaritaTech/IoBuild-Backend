namespace IoBuilt.API.Subscriptions.Domain.Model.Commands;

public record CreateSubscriptionCommand(
    int BuilderId,
    int PlanId,
    string Status,
    DateTime? StartDate,
    DateTime? EndDate
);
