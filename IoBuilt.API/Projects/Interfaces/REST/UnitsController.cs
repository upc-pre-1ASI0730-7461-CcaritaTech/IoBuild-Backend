using System.Net.Mime;
using IoBuilt.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using IoBuilt.API.Projects.Domain.Model.Queries;
using IoBuilt.API.Projects.Domain.Services;
using IoBuilt.API.Projects.Interfaces.REST.Resources;
using IoBuilt.API.Projects.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IoBuilt.API.Projects.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Unit Endpoints.")]
public class UnitsController(IUnitQueryService unitQueryService, IUnitCommandService unitCommandService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get All Units", "Get all units.", OperationId = "GetAllUnits")]
    [SwaggerResponse(200, "The units were found and returned.", typeof(IEnumerable<UnitResource>))]
    public async Task<IActionResult> GetAllUnits()
    {
        var getAllUnitsQuery = new GetAllUnitsQuery();
        var units = await unitQueryService.Handle(getAllUnitsQuery);
        var unitResources = units.Select(UnitResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(unitResources);
    }
    
    [HttpGet("{unitId:int}")]
    [SwaggerOperation("Get Unit by Id", "Get a unit by its unique identifier.", OperationId = "GetUnitById")]
    [SwaggerResponse(200, "The unit was found and returned.", typeof(UnitResource))]
    [SwaggerResponse(404, "The unit was not found.")]
    public async Task<IActionResult> GetUnitById(int unitId)
    {
        var getUnitByIdQuery = new GetUnitByIdQuery(unitId);
        var unit = await unitQueryService.Handle(getUnitByIdQuery);
        if (unit is null) return NotFound();
        var unitResource = UnitResourceFromEntityAssembler.ToResourceFromEntity(unit);
        return Ok(unitResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Unit", "Creates a new unit.", OperationId = "CreateUnit")]
    [SwaggerResponse(201, "Unit created.", typeof(UnitResource))]
    [SwaggerResponse(400, "The request is invalid.")]
    public async Task<IActionResult> CreateUnit([FromBody] CreateUnitResource resource)
    {
        var createUnitCommand = CreateUnitCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await unitCommandService.Handle(createUnitCommand);
        if (result is null) return BadRequest();
        var unitResource = UnitResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetUnitById), new { unitId = unitResource.Id }, unitResource);
    }
}
