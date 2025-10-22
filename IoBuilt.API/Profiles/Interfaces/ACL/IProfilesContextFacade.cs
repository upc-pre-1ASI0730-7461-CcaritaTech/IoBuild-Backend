using IoBuilt.API.Profiles.Interfaces.REST.Resources;

namespace IoBuilt.API.Profiles.Interfaces.ACL;

/// <summary>
/// Facade for the profiles context
/// </summary>
public interface IProfilesContextFacade
{
    /// <summary>
    /// Fetch profile by user id
    /// </summary>
    /// <param name="userId">
    /// User id of the profile to fetch
    /// </param>
    /// <returns>
    /// The profile resource if found, null otherwise
    /// </returns>
    Task<ProfileResource?> FetchProfileByUserId(int userId);
}
