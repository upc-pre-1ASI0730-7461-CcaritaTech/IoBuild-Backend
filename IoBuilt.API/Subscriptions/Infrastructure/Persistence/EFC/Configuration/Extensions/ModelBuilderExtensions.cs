using IoBuilt.API.Subscriptions.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Subscriptions.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySubscriptionsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Subscription>().ToTable("subscriptions");
        builder.Entity<Subscription>().HasKey(x => x.Id);
        builder.Entity<Subscription>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subscription>().Property(x => x.BuilderId).IsRequired();
        builder.Entity<Subscription>().Property(x => x.Plan).IsRequired().HasMaxLength(100);
        builder.Entity<Subscription>().Property(x => x.Status).IsRequired().HasMaxLength(50);
        builder.Entity<Subscription>().Property(x => x.StartDate);
        builder.Entity<Subscription>().Property(x => x.EndDate);
        builder.Entity<Subscription>().Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();

        builder.Entity<Subscription>().Property(x => x.Features)
            .HasConversion(
                v => string.Join('|', v ?? new List<string>()),
                v => string.IsNullOrWhiteSpace(v) ? new List<string>() : v.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
        
        // Plan Configuration
        builder.Entity<Plan>().ToTable("plans");
        builder.Entity<Plan>().HasKey(x => x.Id);
        builder.Entity<Plan>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Plan>().Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Entity<Plan>().Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Plan>().Property(x => x.MaxDevices).IsRequired();
        builder.Entity<Plan>().Property(x => x.MaxAdministrators).IsRequired();
        builder.Entity<Plan>().Property(x => x.SupportLevel).IsRequired().HasMaxLength(100);
        builder.Entity<Plan>().Property(x => x.HasAPI).IsRequired();
        builder.Entity<Plan>().Property(x => x.HasAnalytics).IsRequired();
        
        builder.Entity<Plan>().Property(x => x.Features)
            .HasConversion(
                v => string.Join('|', v ?? new List<string>()),
                v => string.IsNullOrWhiteSpace(v) ? new List<string>() : v.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
    }
}