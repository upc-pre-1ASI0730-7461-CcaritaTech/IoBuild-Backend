using System.Net.Mime;
using IoBuilt.API.Monitoring.Domain.Model.Queries;
using IoBuilt.API.Monitoring.Domain.Services;
using IoBuilt.API.Monitoring.Interfaces.REST.Resources;
using IoBuilt.API.Monitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IoBuilt.API.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Device Endpoints.")]
public class DevicesController(IDeviceQueryService deviceQueryService) : ControllerBase
{
    [HttpGet("{deviceId:int}")]
    [SwaggerOperation("Get Device by Id", "Get a device by its unique identifier.", OperationId = "GetDeviceById")]
    [SwaggerResponse(200, "The device was found and returned.", typeof(DeviceResource))]
    [SwaggerResponse(404, "The device was not found.")]
    public async Task<IActionResult> GetDeviceById(int deviceId)
    {
        var getDeviceByIdQuery = new GetDeviceByIdQuery(deviceId);
        var device = await deviceQueryService.Handle(getDeviceByIdQuery);
        if (device is null) return NotFound();
        var deviceResource = DeviceResourceFromEntityAssembler.ToResourceFromEntity(device);
        return Ok(deviceResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Devices", "Get all devices.", OperationId = "GetAllDevices")]
    [SwaggerResponse(200, "The devices were found and returned.", typeof(IEnumerable<DeviceResource>))]
    public async Task<IActionResult> GetAllDevices()
    {
        var getAllDevicesQuery = new GetAllDevicesQuery();
        var devices = await deviceQueryService.Handle(getAllDevicesQuery);
        var deviceResources = devices.Select(DeviceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(deviceResources);
    }
}