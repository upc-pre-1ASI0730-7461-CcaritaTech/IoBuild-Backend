namespace IoBuilt.API.Subscriptions.Interfaces.ACL;

/// <summary>
/// Anti-Corruption Layer Facade for Subscriptions Bounded Context
/// This interface exposes only what other bounded contexts need to know about subscriptions and plans
/// </summary>
public interface ISubscriptionsContextFacade
{
    /// <summary>
    /// Fetches a plan ID by its name
    /// </summary>
    /// <param name="planName">The name of the plan (e.g., "Starter", "Professional", "Enterprise")</param>
    /// <returns>The plan ID if found, null otherwise</returns>
    Task<int?> FetchPlanIdByNameAsync(string planName);
    
    /// <summary>
    /// Validates if a plan exists by its ID
    /// </summary>
    /// <param name="planId">The ID of the plan to validate</param>
    /// <returns>True if the plan exists, false otherwise</returns>
    Task<bool> ValidatePlanExistsAsync(int planId);
    
    /// <summary>
    /// Gets basic plan information by ID
    /// </summary>
    /// <param name="planId">The ID of the plan</param>
    /// <returns>A tuple with (Name, Price, MaxDevices, MaxAdministrators) or null if not found</returns>
    Task<(string Name, decimal Price, int MaxDevices, int MaxAdministrators)?> FetchPlanDetailsAsync(int planId);
}

