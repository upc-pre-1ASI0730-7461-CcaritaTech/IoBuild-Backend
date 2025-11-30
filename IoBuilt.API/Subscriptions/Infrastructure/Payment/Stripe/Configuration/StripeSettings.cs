namespace IoBuilt.API.Subscriptions.Infrastructure.Payment.Stripe.Configuration;

/// <summary>
/// Configuration settings for Stripe payment integration
/// </summary>
public class StripeSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public string PublishableKey { get; set; } = string.Empty;
}

