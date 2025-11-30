namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

/// <summary>
/// Request to confirm a payment after Stripe checkout
/// </summary>
public record ConfirmPaymentResource(
    int BuilderId,
    string SessionId);

