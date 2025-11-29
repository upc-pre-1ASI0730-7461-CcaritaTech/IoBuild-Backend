using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IoBuilt.API.Clients.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyClientsConfiguration(this ModelBuilder builder)
    {
        // Clients Context
        
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(c => c.FullName).IsRequired().HasMaxLength(200);
        builder.Entity<Client>().Property(c => c.Email).IsRequired().HasMaxLength(255);
        builder.Entity<Client>().Property(c => c.PhoneNumber).HasMaxLength(20);
        builder.Entity<Client>().Property(c => c.Address).HasMaxLength(500);
        builder.Entity<Client>().Property(c => c.ProjectId).IsRequired();
        builder.Entity<Client>().Property(c => c.ProjectName).IsRequired().HasMaxLength(200);
        builder.Entity<Client>().Property(c => c.AccountStatement).IsRequired().HasConversion(new EnumToStringConverter<EAccountStatement>());
    }
}

