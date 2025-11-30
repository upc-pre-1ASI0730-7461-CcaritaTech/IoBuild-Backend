using IoBuilt.API.Shared.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using IoBuilt.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using IoBuilt.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using IoBuilt.API.Devices.Application.Internal.CommandServices;
using IoBuilt.API.Devices.Application.Internal.QueryServices;
using IoBuilt.API.Devices.Domain.Repositories;
using IoBuilt.API.Devices.Domain.Services;
using IoBuilt.API.Devices.Infrastructure.Persistence.EFC.Repositories;
using IoBuilt.API.Subscriptions.Application.Internal.CommandServices;
using IoBuilt.API.Subscriptions.Application.Internal.QueryServices;
using IoBuilt.API.Subscriptions.Domain.Repositories;
using IoBuilt.API.Subscriptions.Domain.Services;
using IoBuilt.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS Policy (configurable)
// Reads AllowedOrigins from configuration. In Development we allow any origin for convenience.
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            // Development: allow all origins to simplify local testing
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
        else if (allowedOrigins != null && allowedOrigins.Length > 0)
        {
            // Production: only allow configured origins
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
        else
        {
            // Fallback: no origins explicitly allowed (CORS will block cross-origin requests).
            // We still allow methods/headers for same-origin requests.
            policy.AllowAnyMethod().AllowAnyHeader();
        }
    });
});

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "IoBuiltAPI",
            Version = "v1",
            Description = "Io built API",
            TermsOfService = new Uri("https://io-build.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "Ccarita Tech",
                Email = "contact@ccaritatech.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Projects Bounded Context
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Services.IProjectCommandService, IoBuilt.API.Projects.Application.Internal.CommandServices.ProjectCommandService>();
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Repositories.IProjectRepository, IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Repositories.ProjectRepository>();
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Services.IProjectQueryService, IoBuilt.API.Projects.Application.Internal.QueryServices.ProjectQueryService>();
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Repositories.IUnitRepository, IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Repositories.UnitRepository>();
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Services.IUnitCommandService, IoBuilt.API.Projects.Application.Internal.CommandServices.UnitCommandService>();
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Services.IUnitQueryService, IoBuilt.API.Projects.Application.Internal.QueryServices.UnitQueryService>();

// IAM Bounded Context
builder.Services.AddScoped<IoBuilt.API.IAM.Domain.Repositories.IUserRepository, IoBuilt.API.IAM.Infrastructure.Persistence.EFC.Repositories.UserRepository>();
builder.Services.AddScoped<IoBuilt.API.IAM.Domain.Services.IUserQueryService, IoBuilt.API.IAM.Application.Internal.QueryServices.UserQueryService>();
builder.Services.AddScoped<IoBuilt.API.IAM.Domain.Services.IUserCommandService, IoBuilt.API.IAM.Application.Internal.CommandServices.UserCommandService>();
builder.Services.AddScoped<IoBuilt.API.IAM.Application.Internal.OutboundServices.ITokenService, IoBuilt.API.IAM.Infrastructure.Tokens.JWT.Services.TokenService>();
builder.Services.AddScoped<IoBuilt.API.IAM.Application.Internal.OutboundServices.IHashingService, IoBuilt.API.IAM.Infrastructure.Hashing.BCrypt.Services.HashingService>();

// Profiles Bounded Context
builder.Services.AddScoped<IoBuilt.API.Profiles.Domain.Repositories.IProfileRepository, IoBuilt.API.Profiles.Infrastructure.Persistence.EFC.Repositories.ProfileRepository>();
builder.Services.AddScoped<IoBuilt.API.Profiles.Domain.Services.IProfileQueryService, IoBuilt.API.Profiles.Application.Internal.QueryServices.ProfileQueryService>();
builder.Services.AddScoped<IoBuilt.API.Profiles.Domain.Services.IProfileCommandService, IoBuilt.API.Profiles.Application.Internal.CommandServices.ProfileCommandService>();
builder.Services.AddScoped<IoBuilt.API.Profiles.Interfaces.ACL.IProfilesContextFacade, IoBuilt.API.Profiles.Application.ACL.ProfilesContextFacade>();



// Monitoring Bounded Context
//builder.Services.AddScoped<IoBuilt.API.Monitoring.Domain.Repositories.IDeviceRepository, IoBuilt.API.Monitoring.Infrastructure.Persistence.EFC.Repositories.DeviceRepository>();
//builder.Services.AddScoped<IoBuilt.API.Monitoring.Domain.Services.IDeviceQueryService, IoBuilt.API.Monitoring.Application.Internal.QueryServices.DeviceQueryService>();

//Devices Bounded Context
// Devices Bounded Context
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceCommandService, DeviceCommandService>();
builder.Services.AddScoped<IDeviceQueryService, DeviceQueryService>();
builder.Services.AddScoped<IoBuilt.API.Devices.Domain.Repositories.IDeviceLogRepository, IoBuilt.API.Devices.Infrastructure.Persistence.EFC.Repositories.DeviceLogRepository>();

// Subscriptions Bounded Context
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();
builder.Services.AddScoped<IPlanRepository, IoBuilt.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories.PlanRepository>();
builder.Services.AddScoped<IPlanQueryService, IoBuilt.API.Subscriptions.Application.Internal.QueryServices.PlanQueryService>();
builder.Services.AddScoped<IoBuilt.API.Subscriptions.Interfaces.ACL.ISubscriptionsContextFacade, IoBuilt.API.Subscriptions.Application.ACL.SubscriptionsContextFacade>();

// Stripe Payment Configuration
builder.Services.Configure<IoBuilt.API.Subscriptions.Infrastructure.Payment.Stripe.Configuration.StripeSettings>(
    builder.Configuration.GetSection("StripeSettings"));
builder.Services.AddScoped<IoBuilt.API.Subscriptions.Infrastructure.Payment.Stripe.Services.StripePaymentService>();

// Analytics Bounded Context
builder.Services.AddScoped<IoBuilt.API.Analytics.Domain.Services.IAnalyticsQueryService, IoBuilt.API.Analytics.Application.Internal.QueryServices.AnalyticsQueryService>();
builder.Services.AddScoped<IoBuilt.API.Analytics.Interfaces.ACL.IDevicesContextFacade, IoBuilt.API.Analytics.Application.ACL.DevicesContextFacade>();
builder.Services.AddScoped<IoBuilt.API.Analytics.Interfaces.ACL.IProjectsContextFacade, IoBuilt.API.Analytics.Application.ACL.ProjectsContextFacade>();

// IAM Bounded Context

// TokenSettings Configuration
builder.Services.Configure<IoBuilt.API.IAM.Infrastructure.Tokens.JWT.Configuration.TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
// Dependency Injection for IAM Bounded Context


// Mediator Configuration

// Add Mediator Injection Configuration
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

// Add Cortex Mediator for Event Handling
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: new[] { typeof(Program) }, configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
        //options.AddDefaultBehaviors();
    });

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    
    // Seed Plans and Subscriptions at runtime (they have List<string> properties with conversions)
    IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions.DbContextSeedHelper.SeedPlansAndSubscriptions(context);
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


// Apply CORS Policy
app.UseCors("DefaultCorsPolicy");

// Add Authorization Middleware to Pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
