namespace IoBuilt.API.Projects.Domain.Model.Aggregates;

/// <summary>
/// Represents a Unit entity within a Project in the Projects bounded context.
/// 
/// A Unit is an individual property unit (such as an apartment or office) within a project
/// that can be owned by a client. It maintains a reference to its parent project and stores
/// ownership information.
/// </summary>
public class Unit
{
    /// <summary>
    /// Gets the unique identifier of the unit.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the identifier of the project that this unit belongs to.
    /// </summary>
    public int ProjectId { get; private set; }

    /// <summary>
    /// Gets or sets the unit number or identifier within the project (e.g., "101", "A-203").
    /// </summary>
    public string UnitNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the identifier of the client who owns this unit.
    /// </summary>
    public int OwnerId { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Unit"/> class with the specified parameters.
    /// </summary>
    /// <param name="projectId">The identifier of the project that this unit belongs to.</param>
    /// <param name="unitNumber">The unit number or identifier within the project.</param>
    /// <param name="ownerId">The identifier of the client who owns this unit.</param>
    public Unit(int projectId, string unitNumber, int ownerId)
    {
        ProjectId = projectId;
        UnitNumber = unitNumber;
        OwnerId = ownerId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Unit"/> class. This constructor is protected
    /// and is used by Entity Framework for model binding and materialization purposes.
    /// </summary>
    protected Unit() { }

    /// <summary>
    /// Updates the unit information with the specified parameters.
    /// </summary>
    /// <param name="unitNumber">The new unit number or identifier within the project.</param>
    /// <param name="ownerId">The new identifier of the client who owns this unit.</param>
    public void Update(string unitNumber, int ownerId)
    {
        UnitNumber = unitNumber;
        OwnerId = ownerId;
    }
}
