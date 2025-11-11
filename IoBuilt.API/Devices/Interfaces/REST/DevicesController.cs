using IoBuilt.API.Devices.Domain.Services;
using IoBuilt.API.Devices.Domain.Model.Commands;
using IoBuilt.API.Devices.Domain.Model.Queries;
using IoBuilt.API.Devices.Interfaces.REST.Resources;
using IoBuilt.API.Devices.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace IoBuilt.API.Devices.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class DevicesController : ControllerBase
{
    private readonly IDeviceCommandService _commandService;
    private readonly IDeviceQueryService _queryService;

    public DevicesController(IDeviceCommandService commandService, IDeviceQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IEnumerable<DeviceResource>> GetAll()
    {
        var devices = await _queryService.Handle(new GetAllDevicesQuery());
        return devices.Select(DeviceResourceFromEntityAssembler.ToResource);
    }

    [HttpGet("{deviceId}")]
    public async Task<DeviceResource?> GetById([FromRoute] int deviceId)
    {
        var device = await _queryService.Handle(new GetDeviceByIdQuery(deviceId));
        return device is null ? null : DeviceResourceFromEntityAssembler.ToResource(device);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDeviceResource resource)
    {
        var command = DeviceResourceToCommandAssembler.ToCommand(resource);
        var id = await _commandService.Handle(command);
        return Created($"api/v1/devices/{id}", new { Id = id });
    }

    [HttpPut("{deviceId}")]
    public async Task<IActionResult> Update([FromRoute] int deviceId, [FromBody] UpdateDeviceResource resource)
    {
        var command = DeviceResourceToCommandAssembler.ToCommand(deviceId, resource);
        await _commandService.Handle(command);
        return Ok();
    }

    [HttpDelete("{deviceId}")]
    public async Task<IActionResult> Delete([FromRoute] int deviceId)
    {
        await _commandService.Handle(new DeleteDeviceCommand(deviceId));
        return NoContent();
    }
}
