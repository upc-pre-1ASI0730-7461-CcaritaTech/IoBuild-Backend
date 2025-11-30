using IoBuilt.API.Subscriptions.Infrastructure.Payment.Stripe.Services;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;

namespace IoBuilt.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/subscriptions/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly StripePaymentService _paymentService;

    public PaymentsController(StripePaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Create a Stripe checkout session for a subscription plan
    /// </summary>
    /// <param name="resource">Payment session request details</param>
    /// <returns>Checkout session information with URL to redirect user</returns>
    [HttpPost("create-session")]
    public async Task<ActionResult<PaymentSessionResource>> CreateCheckoutSession(
        [FromBody] CreatePaymentSessionResource resource)
    {
        try
        {
            var (sessionId, checkoutUrl, amountInCents) = await _paymentService.CreateCheckoutSessionAsync(
                resource.BuilderId,
                resource.PlanId,
                resource.SuccessUrl,
                resource.CancelUrl);

            // Get plan name for response (you might want to inject IPlanQueryService for this)
            var response = new PaymentSessionResource(
                SessionId: sessionId,
                CheckoutUrl: checkoutUrl,
                AmountInCents: amountInCents,
                Currency: "pen",
                PlanId: resource.PlanId,
                PlanName: "Subscription Plan");

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating checkout session", error = ex.Message });
        }
    }

    /// <summary>
    /// Confirm a payment after successful Stripe checkout
    /// </summary>
    /// <param name="resource">Payment confirmation details</param>
    /// <returns>Subscription status and information</returns>
    [HttpPost("confirm")]
    public async Task<ActionResult<PaymentConfirmationResource>> ConfirmPayment(
        [FromBody] ConfirmPaymentResource resource)
    {
        try
        {
            var (status, subscriptionId, isNewSubscription) = await _paymentService.ConfirmPaymentAsync(
                resource.BuilderId,
                resource.SessionId);

            var response = new PaymentConfirmationResource(
                Status: status,
                SubscriptionId: subscriptionId,
                IsNewSubscription: isNewSubscription);

            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error confirming payment", error = ex.Message });
        }
    }
}

