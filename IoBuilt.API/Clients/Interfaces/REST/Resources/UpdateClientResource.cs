namespace IoBuilt.API.Clients.Interfaces.REST.Resources;

public record UpdateClientResource(
    string FullName,
    int ProjectId,
    string ProjectName,
    string AccountStatement,
    string Email,
    string PhoneNumber,
    string Address);

