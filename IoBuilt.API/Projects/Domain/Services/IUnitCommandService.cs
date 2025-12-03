using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Commands;

namespace IoBuilt.API.Projects.Domain.Services;

/// <summary>
/// Defines the contract for handling command operations on units.
/// 
/// This interface specifies the methods for executing domain commands that modify
/// the state of units.
/// </summary>
public interface IUnitCommandService
{
    /// <summary>
    /// Asynchronously handles a command to create a new unit.
    /// </summary>
    /// <param name="command">The command containing the unit creation details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains
    /// the newly created unit, or null if the creation failed.</returns>
    Task<Unit?> Handle(CreateUnitCommand command);
}
