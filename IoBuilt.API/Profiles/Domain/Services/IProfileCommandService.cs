using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using IoBuilt.API.Profiles.Domain.Model.Commands;

namespace IoBuilt.API.Profiles.Domain.Services;

/// <summary>
/// Profile Command Service interface
/// </summary>
/// <remarks>
/// This interface defines the contract for the Profile command service.
/// </remarks>
public interface IProfileCommandService
{
    /// <summary>
    /// Handle Create Profile Command
    /// </summary>
    /// <param name="command">The <see cref="CreateProfileCommand"/> command</param>
    /// <returns>The created <see cref="Profile"/> object</returns>
    Task<Profile?> Handle(CreateProfileCommand command);
}
