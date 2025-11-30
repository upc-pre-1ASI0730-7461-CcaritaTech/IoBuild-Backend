namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

/// <summary>
/// Response containing Stripe checkout session information
/// </summary>
public record PaymentSessionResource(
    string SessionId,
    string CheckoutUrl,
    long AmountInCents,
    string Currency,
    int PlanId,
    string PlanName);

