
namespace IoBuilt.API.Subscriptions.Domain.Model.Commands;

public record CreatePlanCommand(
    string Name,
    decimal Price,
    string Description,
    List<string> Features,
    int MaxDevices,
    int MaxAdministrators,
    string SupportLevel,
    bool HasAPI,
    bool HasAnalytics);


