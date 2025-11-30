namespace IoBuilt.API.Subscriptions.Domain.Model.Aggregates;

public class Plan
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Description { get; private set; } = string.Empty;
    
    // Stored as a delimited string via EF conversion
    public List<string> Features { get; private set; } = new();
    
    public int MaxDevices { get; private set; }
    public int MaxAdministrators { get; private set; }
    public string SupportLevel { get; private set; } = string.Empty;
    public bool HasAPI { get; private set; }
    public bool HasAnalytics { get; private set; }

    // Parameterless constructor for EF Core
    protected Plan() { }

    public Plan(
        string name, 
        decimal price, 
        string description, 
        List<string> features, 
        int maxDevices, 
        int maxAdministrators, 
        string supportLevel, 
        bool hasAPI, 
        bool hasAnalytics)
    {
        Name = name;
        Price = price;
        Description = description;
        Features = features;
        MaxDevices = maxDevices;
        MaxAdministrators = maxAdministrators;
        SupportLevel = supportLevel;
        HasAPI = hasAPI;
        HasAnalytics = hasAnalytics;
    }

    public void Update(
        string? name = null,
        decimal? price = null,
        string? description = null,
        IEnumerable<string>? features = null,
        int? maxDevices = null,
        int? maxAdministrators = null,
        string? supportLevel = null,
        bool? hasAPI = null,
        bool? hasAnalytics = null)
    {
        if (!string.IsNullOrWhiteSpace(name)) Name = name;
        if (price.HasValue) Price = price.Value;
        if (!string.IsNullOrWhiteSpace(description)) Description = description;
        if (features != null) Features = features.ToList();
        if (maxDevices.HasValue) MaxDevices = maxDevices.Value;
        if (maxAdministrators.HasValue) MaxAdministrators = maxAdministrators.Value;
        if (!string.IsNullOrWhiteSpace(supportLevel)) SupportLevel = supportLevel;
        if (hasAPI.HasValue) HasAPI = hasAPI.Value;
        if (hasAnalytics.HasValue) HasAnalytics = hasAnalytics.Value;
    }
}

