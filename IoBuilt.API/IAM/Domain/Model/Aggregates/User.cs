namespace IoBuilt.API.IAM.Domain.Model.Aggregates;

/// <summary>
/// User Aggregate Root
/// </summary>
/// <remarks>
/// This class represents the User aggregate root.
/// It contains the properties and methods to manage the user information.
/// </remarks>
public partial class User
{
    public int Id { get; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    public User()
    {
        Email = string.Empty;
        Password = string.Empty;
        Role = string.Empty;
    }
    
    public User(string email, string password, string role)
    {
        Email = email;
        Password = password;
        Role = role;
    }
}