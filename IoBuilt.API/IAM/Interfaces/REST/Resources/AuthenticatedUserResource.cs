namespace IoBuilt.API.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Email, string Role, string Token);
