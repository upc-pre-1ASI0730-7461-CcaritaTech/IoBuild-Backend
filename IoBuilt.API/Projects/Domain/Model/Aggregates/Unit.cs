namespace IoBuilt.API.Projects.Domain.Model.Aggregates;

public class Unit
{
    public int Id { get; private set; }
    public int ProjectId { get; private set; }
    public string UnitNumber { get; private set; } = string.Empty;
    public int OwnerId { get; private set; }

    public Unit(int projectId, string unitNumber, int ownerId)
    {
        ProjectId = projectId;
        UnitNumber = unitNumber;
        OwnerId = ownerId;
    }

    protected Unit() { }

    public void Update(string unitNumber, int ownerId)
    {
        UnitNumber = unitNumber;
        OwnerId = ownerId;
    }
}
