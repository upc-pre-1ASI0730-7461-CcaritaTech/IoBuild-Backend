namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

/// <summary>
/// Request to create a checkout session for a subscription payment
/// </summary>
public record CreatePaymentSessionResource(
    int BuilderId,
    int PlanId,
    string SuccessUrl,
    string CancelUrl);
