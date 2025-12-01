using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;
namespace IoBuilt.API.Subscriptions.Application.Internal.CommandServices;
/// <summary>
/// Command service for Plan.
/// Handles creation and update of Plan aggregates using the injected repository.
/// </summary>
public class PlanCommandService(IPlanRepository repository) : IPlanCommandService
{
    /// <summary>
    /// Create a new Plan from the provided command, persist it and return its Id.
    /// The method constructs the aggregate, adds it to the repository and saves changes.
    /// </summary>
    public async Task<int> Handle(CreatePlanCommand command)
    {
        var plan = new Plan(
            command.Name,
            command.Price,
            command.Description,
            command.Features,
            command.MaxDevices,
            command.MaxAdministrators,
            command.SupportLevel,
            command.HasAPI,
            command.HasAnalytics
        );
        await repository.AddAsync(plan);
        await repository.SaveChangesAsync();
        return plan.Id;
    }

    /// <summary>
    /// Update an existing Plan with values from the command and persist changes.
    /// Finds the Plan by Id, applies domain update and saves; throws if not found.
    /// </summary>
    public async Task Handle(UpdatePlanCommand command)
    {
        var plan = await repository.FindByIdAsync(command.Id);
        if (plan is null) throw new Exception($"Plan with id {command.Id} not found");

        plan.Update(
            command.Name,
            command.Price,
            command.Description,
            command.Features,
            command.MaxDevices,
            command.MaxAdministrators,
            command.SupportLevel,
            command.HasAPI,
            command.HasAnalytics
        );
        repository.Update(plan);
        await repository.SaveChangesAsync();
    }
}
