namespace IoBuilt.API.Projects.Domain.Model.ValueObjects;

/// <summary>
/// Represents the possible status values for a project.
/// 
/// This enumeration defines the lifecycle states that a project can have from its creation
/// through completion or cancellation.
/// </summary>
public enum EProjectStatus
{
    /// <summary>
    /// The project is in the planning phase and has not yet started construction.
    /// </summary>
    Planned,

    /// <summary>
    /// The project is currently under construction or development.
    /// </summary>
    OnGoing,

    /// <summary>
    /// The project has been temporarily suspended and is not currently progressing.
    /// </summary>
    OnHold,

    /// <summary>
    /// The project has been successfully finished and all work is complete.
    /// </summary>
    Completed,

    /// <summary>
    /// The project has been cancelled and will not proceed to completion.
    /// </summary>
    Cancelled
}