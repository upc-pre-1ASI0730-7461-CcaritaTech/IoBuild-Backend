namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

/// <summary>
/// Response after confirming a payment
/// </summary>
public record PaymentConfirmationResource(
    string Status,
    int SubscriptionId,
    bool IsNewSubscription);

