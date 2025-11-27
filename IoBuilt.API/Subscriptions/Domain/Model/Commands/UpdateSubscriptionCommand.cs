namespace IoBuilt.API.Subscriptions.Domain.Model.Commands;

public record UpdateSubscriptionCommand(
    int Id,
    string? Plan,
    string? Status,
    DateTime? StartDate,
    DateTime? EndDate,
    decimal? Price,
    IEnumerable<string>? Features);

