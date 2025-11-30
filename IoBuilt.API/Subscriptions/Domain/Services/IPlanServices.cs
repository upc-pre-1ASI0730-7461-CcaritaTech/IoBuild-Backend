using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Domain.Model.Queries;

namespace IoBuilt.API.Subscriptions.Domain.Services;

public interface IPlanCommandService
{
    Task<int> Handle(CreatePlanCommand command);
    Task Handle(UpdatePlanCommand command);
}

public interface IPlanQueryService
{
    Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query);
    Task<Plan?> Handle(GetPlanByIdQuery query);
    Task<Plan?> Handle(GetPlanByNameQuery query);
}

