using IoBuilt.API.Subscriptions.Domain.Model.Commands;
using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Services;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;
using IoBuilt.API.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace IoBuilt.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionCommandService _commandService;
    private readonly ISubscriptionQueryService _queryService;

    public SubscriptionsController(ISubscriptionCommandService commandService, ISubscriptionQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IEnumerable<SubscriptionResource>> GetAll()
    {
        var entities = await _queryService.Handle(new GetAllSubscriptionsQuery());
        return entities.Select(SubscriptionResourceFromEntityAssembler.ToResource);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubscriptionResource?>> GetById([FromRoute] int id)
    {
        var entity = await _queryService.Handle(new GetSubscriptionByIdQuery(id));
        if (entity is null) return NotFound();
        return SubscriptionResourceFromEntityAssembler.ToResource(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionResource resource)
    {
        var command = SubscriptionResourceToCommandAssembler.ToCommand(resource);
        var id = await _commandService.Handle(command);
        return Created($"api/v1/subscriptions/{id}", new { Id = id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubscriptionResource resource)
    {
        var command = SubscriptionResourceToCommandAssembler.ToCommand(id, resource);
        await _commandService.Handle(command);
        return Ok();
    }
}
