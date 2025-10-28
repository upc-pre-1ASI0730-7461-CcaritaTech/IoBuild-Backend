using IoBuilt.API.IAM.Domain.Model.Aggregates;
using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderSeedDataExtensions
{
    public static void ApplySeedData(this ModelBuilder builder)
    {
        // Seed Users
        builder.Entity<User>().HasData(
            new
            {
                Id = 1,
                Email = "builder@iobuilt.com",
                PasswordHash = BCryptNet.HashPassword("Builder123!"),
                Role = "builder"
            },
            new
            {
                Id = 2,
                Email = "owner@iobuilt.com",
                PasswordHash = BCryptNet.HashPassword("Owner123!"),
                Role = "owner"
            }
        );

        // Seed Profiles
        builder.Entity<Profile>().HasData(
            new
            {
                Id = 1,
                UserId = 1,
                PhotoUrl = "https://randomuser.me/api/portraits/men/32.jpg",
                Name = "Juan Pérez",
                Username = "juan_builder",
                Address = "Av. Javier Prado 123, San Isidro, Lima",
                Age = 35,
                PhoneNumber = "+51 987654321"
            },
            new
            {
                Id = 2,
                UserId = 2,
                PhotoUrl = "https://randomuser.me/api/portraits/women/44.jpg",
                Name = "María González",
                Username = "maria_owner",
                Address = "Calle Las Begonias 456, San Borja, Lima",
                Age = 42,
                PhoneNumber = "+51 912345678"
            }
        );
    }
}
