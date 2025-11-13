namespace IoBuilt.API.Analytics.Domain.Model.Entities;

public class MonthlyOccupancyData
{
    public string Month { get; set; } = string.Empty;
    public double OccupancyRate { get; set; }
    public int Year { get; set; }
}
