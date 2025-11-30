using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;
namespace IoBuilt.API.Subscriptions.Application.Internal.CommandServices;
public class PlanCommandService(IPlanRepository repository) : IPlanCommandService
{
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
