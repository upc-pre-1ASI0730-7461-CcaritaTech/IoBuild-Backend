namespace IoBuilt.API.IAM.Interfaces.REST.Resources;

public record UserDetailResource(
    int Id, 
    int UserId, 
    string PhotoUrl, 
    string Name, 
    string Username, 
    string Address, 
    int Age, 
    string PhoneNumber);