using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Application.Internal.CommandServices;

public class UnitCommandService(IUnitRepository unitRepository, IUnitOfWork unitOfWork) : IUnitCommandService
{
    public async Task<Unit?> Handle(CreateUnitCommand command)
    {
        var existingUnit = await unitRepository.FindByProjectIdAndUnitNumberAsync(
            command.ProjectId, 
            command.UnitNumber
        );
        
        if (existingUnit is not null)
            throw new Exception("A unit with the same number already exists in this project");

        var unit = new Unit(command.ProjectId, command.UnitNumber, command.OwnerId);
        
        await unitRepository.AddAsync(unit);
        await unitOfWork.CompleteAsync();
        
        return unit;
    }
}
