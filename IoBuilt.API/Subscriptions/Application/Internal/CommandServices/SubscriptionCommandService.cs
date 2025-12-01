using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;

namespace IoBuilt.API.Subscriptions.Application.Internal.CommandServices;

/// <summary>
/// Command service for Subscription.
/// Handles creation and update of Subscription aggregates via the injected repository.
/// </summary>
public class SubscriptionCommandService : ISubscriptionCommandService
{
    private readonly ISubscriptionRepository _repository;

    public SubscriptionCommandService(ISubscriptionRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Create a new Subscription from the command, persist it and return its Id.
    /// Constructs the aggregate, adds it to the repository and saves changes.
    /// </summary>
    public async Task<int> Handle(CreateSubscriptionCommand command)
    {
        var entity = new Subscription(
            command.BuilderId,
            command.PlanId,
            command.Status,
            command.StartDate,
            command.EndDate);
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return entity.Id;
    }

    /// <summary>
    /// Update an existing Subscription with values from the command and persist changes.
    /// If the subscription is not found, the method returns without throwing.
    /// </summary>
    public async Task Handle(UpdateSubscriptionCommand command)
    {
        var entity = await _repository.FindByIdAsync(command.Id);
        if (entity is null) return;
        entity.Update(command.PlanId, command.Status, command.StartDate, command.EndDate);
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
    }
}
