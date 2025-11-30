namespace IoBuilt.API.Subscriptions.Domain.Model.Aggregates;

public class Subscription
{
    public int Id { get; private set; }
    public int BuilderId { get; private set; }
    public int PlanId { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    // Navigation property
    public Plan Plan { get; private set; } = null!;

    // Parameterless constructor for EF Core
    protected Subscription() { }

    public Subscription(int builderId, int planId, string status, DateTime? startDate, DateTime? endDate)
    {
        BuilderId = builderId;
        PlanId = planId;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void Update(
        int? planId = null,
        string? status = null,
        DateTime? startDate = null,
        DateTime? endDate = null)
    {
        if (planId.HasValue) PlanId = planId.Value;
        if (!string.IsNullOrWhiteSpace(status)) Status = status;
        if (startDate.HasValue) StartDate = startDate;
        if (endDate.HasValue) EndDate = endDate;
    }
}
