using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Model.ValueObjects;

namespace IoBuilt.API.Projects.Domain.Model.Aggregates;

/// <summary>
/// Represents a Project aggregate root in the Projects bounded context.
/// 
/// A Project is a real estate project managed by a builder that contains multiple units.
/// It encapsulates the core business logic for managing project information including
/// its properties, status, units, and builder details.
/// </summary>
public partial class Project
{
    /// <summary>
    /// Gets the unique identifier of the project.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets or sets the name of the project.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the description of the project.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Gets or sets the geographic location of the project.
    /// </summary>
    public string Location { get; private set; }

    /// <summary>
    /// Gets or sets the total number of units in the project.
    /// </summary>
    public int TotalUnits { get; private set; }

    /// <summary>
    /// Gets or sets the number of units currently occupied in the project.
    /// </summary>
    public int OccupiedUnits { get; private set; }

    /// <summary>
    /// Gets or sets the current status of the project.
    /// </summary>
    public EProjectStatus Status { get; private set; }

    /// <summary>
    /// Gets or sets the identifier of the builder who owns this project.
    /// </summary>
    public int BuilderId { get; private set; }

    /// <summary>
    /// Gets or sets the date and time when the project was created.
    /// </summary>
    public DateTime CreatedDate { get; private set; }

    /// <summary>
    /// Gets or sets the URL of the project's image.
    /// </summary>
    public string ImageUrl { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class with default values.
    /// </summary>
    public Project()
    {
        Name = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Status = EProjectStatus.Planned;
        ImageUrl = string.Empty;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the project.</param>
    /// <param name="description">The description of the project.</param>
    /// <param name="location">The geographic location of the project.</param>
    /// <param name="totalUnits">The total number of units in the project.</param>
    /// <param name="occupiedUnits">The number of occupied units in the project.</param>
    /// <param name="status">The status of the project.</param>
    /// <param name="builderId">The identifier of the builder who owns this project.</param>
    /// <param name="createdDate">The date and time when the project was created.</param>
    /// <param name="imageUrl">The URL of the project's image.</param>
    public Project(string name, string description, string location, int totalUnits, int occupiedUnits, EProjectStatus status, int builderId, DateTime createdDate, string imageUrl)
    {
        Name = name;
        Description = description;
        Location = location;
        TotalUnits = totalUnits;
        OccupiedUnits = occupiedUnits;
        Status = status;
        BuilderId = builderId;
        CreatedDate = createdDate;
        ImageUrl = imageUrl;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class from a <see cref="CreateProjectCommand"/>.
    /// </summary>
    /// <param name="command">The command containing the project creation details.</param>
    public Project(CreateProjectCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Location = command.Location;
        TotalUnits = command.TotalUnits;
        OccupiedUnits = 0;
        Status = EProjectStatus.Planned;
        BuilderId = command.BuilderId;
        CreatedDate = new DateTime();
        ImageUrl = command.ImageUrl;
    }

    /// <summary>
    /// Updates the project with the values from the specified <see cref="UpdateProjectCommand"/>.
    /// </summary>
    /// <param name="command">The command containing the updated project information.</param>
    /// <returns>The current instance of the project with updated values.</returns>
    public Project Update(UpdateProjectCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Location = command.Location;
        TotalUnits = command.TotalUnits;
        OccupiedUnits = command.OccupiedUnits;
        Status = command.Status;
        BuilderId = command.BuilderId;
        ImageUrl = command.ImageUrl;
        return this;
    }
}