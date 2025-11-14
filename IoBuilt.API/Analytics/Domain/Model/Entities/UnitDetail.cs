namespace IoBuilt.API.Analytics.Domain.Model.Entities;

public class UnitDetail
{
    public int UnitId { get; set; }
    public string UnitNumber { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;
    public int ActiveDevices { get; set; }
    public string ConnectionStatus { get; set; } = string.Empty;
}
