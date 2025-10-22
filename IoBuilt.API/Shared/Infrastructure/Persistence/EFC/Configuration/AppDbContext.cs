using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IoBuilt.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IoBuilt.API.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IoBuilt.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // IAM Context
        builder.ApplyIamConfiguration();
        
        // Profiles Context
        builder.ApplyProfilesConfiguration();
        
        
        // Projects Context
        builder.ApplyProjectsConfiguration();
        
        // Monitoring Context
        builder.ApplyMonitoringConfiguration();
        
        builder.UseSnakeCaseNamingConvention();
    }
}