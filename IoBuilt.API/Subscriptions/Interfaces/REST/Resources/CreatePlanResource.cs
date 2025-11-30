namespace IoBuilt.API.Subscriptions.Interfaces.REST.Resources;

public record CreatePlanResource(
    string Name,
    decimal Price,
    string Description,
    List<string> Features,
    int MaxDevices,
    int MaxAdministrators,
    string SupportLevel,
    bool HasAPI,
    bool HasAnalytics);

