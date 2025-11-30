using IoBuilt.API.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        // IAM Context
        
        // User Entity
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
        builder.Entity<User>().Property(u => u.Role).IsRequired().HasMaxLength(50);
    }
}
