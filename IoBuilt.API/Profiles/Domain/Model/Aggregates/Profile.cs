namespace IoBuilt.API.Profiles.Domain.Model.Aggregates;

/// <summary>
/// Profile Aggregate Root
/// </summary>
/// <remarks>
/// This class represents the Profile aggregate root.
/// It contains the detailed profile information for a user.
/// </remarks>
public partial class Profile
{
    public int Id { get; }
    public int UserId { get; private set; }
    public string PhotoUrl { get; private set; }
    public string Name { get; private set; }
    public string Username { get; private set; }
    public string Address { get; private set; }
    public int Age { get; private set; }
    public string PhoneNumber { get; private set; }

    public Profile()
    {
        PhotoUrl = string.Empty;
        Name = string.Empty;
        Username = string.Empty;
        Address = string.Empty;
        PhoneNumber = string.Empty;
    }
    
    public Profile(int userId, string photoUrl, string name, string username, string address, int age, string phoneNumber)
    {
        UserId = userId;
        PhotoUrl = photoUrl;
        Name = name;
        Username = username;
        Address = address;
        Age = age;
        PhoneNumber = phoneNumber;
    }
}
