using IoBuilt.API.Shared.Domain.Repositories;
using IoBuilt.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using IoBuilt.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
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

// IAM Bounded Context
builder.Services.AddScoped<IoBuilt.API.IAM.Domain.Repositories.IUserRepository, IoBuilt.API.IAM.Infrastructure.Persistence.EFC.Repositories.UserRepository>();
builder.Services.AddScoped<IoBuilt.API.IAM.Domain.Services.IUserQueryService, IoBuilt.API.IAM.Application.Internal.QueryServices.UserQueryService>();

// Profiles Bounded Context
builder.Services.AddScoped<IoBuilt.API.Profiles.Domain.Repositories.IProfileRepository, IoBuilt.API.Profiles.Infrastructure.Persistence.EFC.Repositories.ProfileRepository>();
builder.Services.AddScoped<IoBuilt.API.Profiles.Domain.Services.IProfileQueryService, IoBuilt.API.Profiles.Application.Internal.QueryServices.ProfileQueryService>();
builder.Services.AddScoped<IoBuilt.API.Profiles.Interfaces.ACL.IProfilesContextFacade, IoBuilt.API.Profiles.Application.ACL.ProfilesContextFacade>();


// Projects Bounded Context
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Repositories.IProjectRepository, IoBuilt.API.Projects.Infrastructure.Persistence.EFC.Repositories.ProjectRepository>();
builder.Services.AddScoped<IoBuilt.API.Projects.Domain.Services.IProjectQueryService, IoBuilt.API.Projects.Application.Internal.QueryServices.ProjectQueryService>();

// Monitoring Bounded Context
builder.Services.AddScoped<IoBuilt.API.Monitoring.Domain.Repositories.IDeviceRepository, IoBuilt.API.Monitoring.Infrastructure.Persistence.EFC.Repositories.DeviceRepository>();
builder.Services.AddScoped<IoBuilt.API.Monitoring.Domain.Services.IDeviceQueryService, IoBuilt.API.Monitoring.Application.Internal.QueryServices.DeviceQueryService>();


// IAM Bounded Context

// TokenSettings Configuration
//builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
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
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

// Add Authorization Middleware to Pipeline
//app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
