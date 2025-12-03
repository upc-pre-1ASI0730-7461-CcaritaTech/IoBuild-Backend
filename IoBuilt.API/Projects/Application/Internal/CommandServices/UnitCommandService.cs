using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Repositories;
using IoBuilt.API.Projects.Domain.Services;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Projects.Application.Internal.CommandServices;

/// <summary>
/// Implements the command service for managing unit operations.
/// 
/// This class handles the business logic for creating units within projects.
/// It enforces domain rules such as preventing duplicate unit numbers within a project.
/// </summary>
public class UnitCommandService(IUnitRepository unitRepository, IUnitOfWork unitOfWork) : IUnitCommandService
{
    /// <summary>
    /// Asynchronously creates a new unit based on the provided command.
    /// </summary>
    /// <param name="command">The command containing the unit creation details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the newly created unit.</returns>
    /// <exception cref="Exception">Thrown if a unit with the same number already exists in the project.</exception>
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
