using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;

namespace IoBuilt.API.Subscriptions.Application.Internal.CommandServices;

public class SubscriptionCommandService : ISubscriptionCommandService
{
    private readonly ISubscriptionRepository _repository;

    public SubscriptionCommandService(ISubscriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateSubscriptionCommand command)
    {
        var entity = new Subscription(
            command.BuilderId,
            command.Plan,
            command.Status,
            command.StartDate,
            command.EndDate,
            command.Price,
            command.Features?.ToList());
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Handle(UpdateSubscriptionCommand command)
    {
        var entity = await _repository.FindByIdAsync(command.Id);
        if (entity is null) return;
        entity.Update(command.Plan, command.Status, command.StartDate, command.EndDate, command.Price, command.Features);
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
    }
}
