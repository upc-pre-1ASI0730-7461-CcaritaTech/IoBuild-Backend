using IoBuilt.API.IAM.Domain.Model.Aggregates;
using IoBuilt.API.Profiles.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.Aggregates;
using IoBuilt.API.Projects.Domain.Model.ValueObjects;
using IoBuilt.API.Devices.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace IoBuilt.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderSeedDataExtensions
{
    public static void ApplySeedData(this ModelBuilder builder)
    {
        // ==================== SEED USERS ====================
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

        // ==================== SEED PROFILES ====================
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

        // ==================== SEED PROJECTS ====================
        // Projects for Builder (User 1 - Juan Pérez)
        builder.Entity<Project>().HasData(
            new
            {
                Id = 1,
                Name = "Residencial Los Álamos",
                Description = "Complejo residencial de lujo con 120 departamentos en San Isidro. Cuenta con áreas verdes, piscina, gimnasio y vigilancia 24/7.",
                Location = "Av. Conquistadores 890, San Isidro, Lima",
                TotalUnits = 120,
                OccupiedUnits = 95,
                Status = EProjectStatus.OnGoing,
                BuilderId = 1,
                CreatedDate = new DateTime(2024, 3, 15),
                ImageUrl = "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00?w=800"
            },
            new
            {
                Id = 2,
                Name = "Torres del Pacífico",
                Description = "Desarrollo de dos torres con vista al mar en Miraflores. 80 departamentos premium con acabados de primera calidad.",
                Location = "Malecón de la Reserva 456, Miraflores, Lima",
                TotalUnits = 80,
                OccupiedUnits = 68,
                Status = EProjectStatus.OnGoing,
                BuilderId = 1,
                CreatedDate = new DateTime(2024, 6, 20),
                ImageUrl = "https://images.unsplash.com/photo-1486406146926-c627a92ad1ab?w=800"
            },
            new
            {
                Id = 3,
                Name = "Condominio Las Casuarinas",
                Description = "Proyecto residencial en construcción con 60 departamentos tipo loft en Surco. Entrega prevista para Q2 2025.",
                Location = "Av. Primavera 1234, Santiago de Surco, Lima",
                TotalUnits = 60,
                OccupiedUnits = 12,
                Status = EProjectStatus.OnGoing,
                BuilderId = 1,
                CreatedDate = new DateTime(2024, 9, 10),
                ImageUrl = "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=800"
            }
        );

        // ==================== SEED DEVICES ====================
        // Devices for Project 1 (Residencial Los Álamos)
        builder.Entity<Device>().HasData(
            new
            {
                Id = 1,
                Name = "Sensor de Temperatura - Torre A",
                Type = "Temperature",
                Location = "Torre A - Piso 5",
                ProjectId = 1,
                Status = "Online",
                MacAddress = "00:11:22:33:44:55"
                
            },
            new
            {
                Id = 2,
                Name = "Monitor de Humedad - Torre B",
                Type = "Humidity",
                Location = "Torre B - Piso 8",
                ProjectId = 1,
                Status = "Online",
                MacAddress = "00:11:22:33:44:56"
            },
            new
            {
                Id = 3,
                Name = "Medidor de Energía - Áreas Comunes",
                Type = "Energy",
                Location = "Áreas Comunes - Gimnasio",
                ProjectId = 1,
                Status = "Online",
                MacAddress = "00:11:22:33:44:57"
            },
            new
            {
                Id = 9,
                Name = "Medidor de Agua - Torre A",
                Type = "Water",
                Location = "Torre A - Sistema Central",
                ProjectId = 1,
                Status = "Online"
            },
            new
            {
                Id = 10,
                Name = "Control Iluminación - Lobby",
                Type = "Lighting",
                Location = "Lobby Principal",
                ProjectId = 1,
                Status = "Online"
            },
            
            // Devices for Project 2 (Torres del Pacífico)
            new
            {
                Id = 4,
                Name = "Sensor de Temperatura - Torre 1",
                Type = "Temperature",
                Location = "Torre 1 - Lobby Principal",
                ProjectId = 2,
                Status = "Online",
                MacAddress = "00:11:22:33:44:58"
            },
            new
            {
                Id = 5,
                Name = "Medidor de Agua - Torre 2",
                Type = "Water",
                Location = "Torre 2 - Sistema Central",
                ProjectId = 2,
                Status = "Online",
                MacAddress = "00:11:22:33:44:59"
            },
            new
            {
                Id = 6,
                Name = "Monitor de Energía - Piscina",
                Type = "Energy",
                Location = "Área de Piscina - Terraza",
                ProjectId = 2,
                Status = "Online",
                MacAddress = "00:11:22:33:44:5A"
            },
            new
            {
                Id = 11,
                Name = "Control de Acceso - Entrada Principal",
                Type = "Access Control",
                Location = "Entrada Principal - Torre 1",
                ProjectId = 2,
                Status = "Online"
            },
            new
            {
                Id = 12,
                Name = "Climatización - Áreas Comunes",
                Type = "HVAC",
                Location = "Áreas Comunes",
                ProjectId = 2,
                Status = "Online"
            },
            
            // Devices for Project 3 (Condominio Las Casuarinas)
            new
            {
                Id = 7,
                Name = "Sensor de Construcción - Área 1",
                Type = "Construction",
                Location = "Zona de Construcción - Sector A",
                ProjectId = 3,
                Status = "Online",
                MacAddress = "00:11:22:33:44:5B"
            },
            new
            {
                Id = 8,
                Name = "Monitor de Seguridad - Perímetro",
                Type = "Security",
                Location = "Perímetro de Obra",
                ProjectId = 3,
                Status = "Online",
                MacAddress = "00:11:22:33:44:5C"
            }
        );

        // ==================== SEED UNITS ====================
        builder.Entity<Unit>().HasData(
            // Units for Owner (User 2 - María González) in Project 1
            new
            {
                Id = 1,
                ProjectId = 1,
                UnitNumber = "A-501",
                OwnerId = 2
            },
            new
            {
                Id = 2,
                ProjectId = 1,
                UnitNumber = "A-502",
                OwnerId = 2
            },
            // Additional units for other owners in Project 1
            new
            {
                Id = 3,
                ProjectId = 1,
                UnitNumber = "B-801",
                OwnerId = 3
            },
            new
            {
                Id = 4,
                ProjectId = 2,
                UnitNumber = "T1-1205",
                OwnerId = 4
            },
            new
            {
                Id = 5,
                ProjectId = 2,
                UnitNumber = "T2-0801",
                OwnerId = 2
            }
        );

        // ==================== SEED DEVICE LOGS ====================
        // Temperature logs for Device 1 (last 30 days)
        var baseDate = DateTime.UtcNow.AddDays(-30);
        var deviceLogs = new List<object>();
        
        // Generate daily temperature averages for Device 1
        for (int i = 0; i < 30; i++)
        {
            deviceLogs.Add(new
            {
                Id = 1000 + i,
                DeviceId = 1,
                Timestamp = baseDate.AddDays(i),
                Value = 22.0 + (Math.Sin(i * 0.2) * 2), // Simulates temperature variation
                Type = "temperature_daily_avg",
                Metadata = "{}"
            });
        }

        // Generate daily energy totals for Device 3
        for (int i = 0; i < 30; i++)
        {
            deviceLogs.Add(new
            {
                Id = 2000 + i,
                DeviceId = 3,
                Timestamp = baseDate.AddDays(i),
                Value = 800.0 + (Math.Sin(i * 0.3) * 100), // Simulates energy consumption
                Type = "energy_daily_total",
                Metadata = "{}"
            });
        }

        // Generate hourly temperature data for Device 4 (last 7 days)
        var recentDate = DateTime.UtcNow.AddDays(-7);
        for (int day = 0; day < 7; day++)
        {
            for (int hour = 0; hour < 24; hour++)
            {
                deviceLogs.Add(new
                {
                    Id = 3000 + (day * 24) + hour,
                    DeviceId = 4,
                    Timestamp = recentDate.AddDays(day).AddHours(hour),
                    Value = 23.0 + (Math.Sin((day * 24 + hour) * 0.1) * 3),
                    Type = "temperature",
                    Metadata = "{}"
                });
            }
        }

        // Generate hourly energy data for Device 6 (last 7 days)
        for (int day = 0; day < 7; day++)
        {
            for (int hour = 0; hour < 24; hour++)
            {
                deviceLogs.Add(new
                {
                    Id = 4000 + (day * 24) + hour,
                    DeviceId = 6,
                    Timestamp = recentDate.AddDays(day).AddHours(hour),
                    Value = 40.0 + (Math.Sin((day * 24 + hour) * 0.15) * 5),
                    Type = "energy",
                    Metadata = "{}"
                });
            }
        }

        // Generate daily water usage data for Device 5 (last 30 days)
        for (int i = 0; i < 30; i++)
        {
            deviceLogs.Add(new
            {
                Id = 5000 + i,
                DeviceId = 5,
                Timestamp = baseDate.AddDays(i),
                Value = 150.0 + (Math.Sin(i * 0.25) * 20), // Water usage in liters
                Type = "water_daily_total",
                Metadata = "{}"
            });
        }

        // Generate weekly water usage for Device 9 (last 7 days)
        for (int i = 0; i < 7; i++)
        {
            deviceLogs.Add(new
            {
                Id = 6000 + i,
                DeviceId = 9,
                Timestamp = recentDate.AddDays(i),
                Value = 120.0 + (Math.Sin(i * 0.4) * 15),
                Type = "water",
                Metadata = "{}"
            });
        }

        builder.Entity<DeviceLog>().HasData(deviceLogs.ToArray());
    }
}
