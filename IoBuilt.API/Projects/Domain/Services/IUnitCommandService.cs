using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;

namespace IoBuilt.API.Projects.Domain.Services;

public interface IUnitCommandService
{
    Task<Unit?> Handle(CreateUnitCommand command);
}
