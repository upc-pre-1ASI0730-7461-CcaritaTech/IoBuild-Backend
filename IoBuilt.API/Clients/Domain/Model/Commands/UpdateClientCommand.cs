using IoBuilt.API.Clients.Domain.Model.ValueObjects;

namespace IoBuilt.API.Clients.Domain.Model.Commands;

public record UpdateClientCommand(
    int Id,
    string FullName, 
    int ProjectId, 
    string ProjectName, 
    EAccountStatement AccountStatement, 
    string Email, 
    string PhoneNumber, 
    string Address
);
