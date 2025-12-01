using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Services;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;
using IoBuilt.API.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace IoBuilt.API.Subscriptions.Interfaces.REST;

/// <summary>
/// REST controller exposing subscription-related endpoints.
/// Coordinates incoming HTTP requests, maps resources to domain commands/queries and
/// delegates handling to the application services (command and query services).
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionCommandService _commandService;
    private readonly ISubscriptionQueryService _queryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionsController"/> class.
    /// </summary>
    /// <param name="commandService">Service responsible for handling subscription commands.</param>
    /// <param name="queryService">Service responsible for handling subscription queries.</param>
    public SubscriptionsController(ISubscriptionCommandService commandService, ISubscriptionQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    /// <summary>
    /// Get all subscriptions.
    /// Maps the query to the <see cref="ISubscriptionQueryService"/> and returns a collection of resources.
    /// </summary>
    /// <returns>An enumerable of <see cref="SubscriptionResource"/> representing all subscriptions.</returns>
    [HttpGet]
    public async Task<IEnumerable<SubscriptionResource>> GetAll()
    {
        var entities = await _queryService.Handle(new GetAllSubscriptionsQuery());
        return entities.Select(SubscriptionResourceFromEntityAssembler.ToResource);
    }

    /// <summary>
    /// Get a subscription by its identifier.
    /// Returns 404 if the subscription is not found.
    /// </summary>
    /// <param name="id">Subscription identifier from the route.</param>
    /// <returns>An <see cref="ActionResult{T}"/> containing the <see cref="SubscriptionResource"/> or NotFound.</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubscriptionResource?>> GetById([FromRoute] int id)
    {
        var entity = await _queryService.Handle(new GetSubscriptionByIdQuery(id));
        if (entity is null) return NotFound();
        return SubscriptionResourceFromEntityAssembler.ToResource(entity);
    }

    /// <summary>
    /// Create a new subscription from the supplied resource.
    /// Maps the incoming resource to a domain command, executes it and returns 201 Created with the new Id.
    /// </summary>
    /// <param name="resource">Request body containing subscription data.</param>
    /// <returns>An <see cref="IActionResult"/> with 201 Created and the created resource id.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionResource resource)
    {
        var command = SubscriptionResourceToCommandAssembler.ToCommand(resource);
        var id = await _commandService.Handle(command);
        return Created($"api/v1/subscriptions/{id}", new { Id = id });
    }

    /// <summary>
    /// Update an existing subscription identified by route Id with the supplied resource values.
    /// Maps the resource to a domain command and delegates to the command service; returns 200 OK on success.
    /// </summary>
    /// <param name="id">Subscription identifier from the route.</param>
    /// <param name="resource">Request body containing updated subscription data.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the outcome (200 OK on success).</returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubscriptionResource resource)
    {
        var command = SubscriptionResourceToCommandAssembler.ToCommand(id, resource);
        await _commandService.Handle(command);
        return Ok();
    }
}
