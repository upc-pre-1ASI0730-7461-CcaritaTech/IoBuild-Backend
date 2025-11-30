namespace IoBuilt.API.Profiles.Interfaces.REST.Resources;

public record UpdateProfileResource(
    string PhotoUrl, 
    string Name, 
    string Username, 
    string Address, 
    int Age, 
    string PhoneNumber);

