namespace IoBuilt.API.Subscriptions.Domain.Model.Commands;

public record CreateSubscriptionCommand(
    int BuilderId,
    string Plan,
    string Status,
    DateTime? StartDate,
    DateTime? EndDate,
    decimal Price,
    IEnumerable<string> Features
);
