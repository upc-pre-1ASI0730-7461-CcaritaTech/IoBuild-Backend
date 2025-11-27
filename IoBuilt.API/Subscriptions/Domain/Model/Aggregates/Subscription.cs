namespace IoBuilt.API.Subscriptions.Domain.Model.Aggregates;

public class Subscription
{
    public int Id { get; private set; }
    public int BuilderId { get; private set; }
    public string Plan { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty;
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public decimal Price { get; private set; }

    // Stored as a delimited string via EF conversion
    public List<string> Features { get; private set; } = new();

    // Parameterless constructor for EF Core
    protected Subscription() { }

    public Subscription(int builderId, string plan, string status, DateTime? startDate, DateTime? endDate, decimal price, List<string>? features = null)
    {
        BuilderId = builderId;
        Plan = plan;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
        if (features != null) Features = features;
    }

    public void Update(
        string? plan = null,
        string? status = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        decimal? price = null,
        IEnumerable<string>? features = null)
    {
        if (!string.IsNullOrWhiteSpace(plan)) Plan = plan;
        if (!string.IsNullOrWhiteSpace(status)) Status = status;
        if (startDate.HasValue) StartDate = startDate;
        if (endDate.HasValue) EndDate = endDate;
        if (price.HasValue) Price = price.Value;
        if (features != null) Features = features.ToList();
    }
}
