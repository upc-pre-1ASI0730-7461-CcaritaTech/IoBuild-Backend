using IoBuilt.API.Projects.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProjectsConfiguration(this ModelBuilder builder)
    {
        // Projects Context
        
        builder.Entity<Project>().HasKey(p => p.Id);
        builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Entity<Project>().Property(p => p.Description).HasMaxLength(1000);
        builder.Entity<Project>().Property(p => p.Location).HasMaxLength(300);
        builder.Entity<Project>().Property(p => p.TotalUnits).IsRequired();
        builder.Entity<Project>().Property(p => p.OccupiedUnits).IsRequired();
        builder.Entity<Project>().Property(p => p.Status).IsRequired().HasMaxLength(50);
        builder.Entity<Project>().Property(p => p.BuilderId).IsRequired();
        builder.Entity<Project>().Property(p => p.CreatedDate).IsRequired();
        builder.Entity<Project>().Property(p => p.ImageUrl).HasMaxLength(500);
    }
}
