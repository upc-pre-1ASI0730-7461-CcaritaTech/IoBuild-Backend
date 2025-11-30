using IoBuilt.API.Subscriptions.Domain.Model.Queries;
using IoBuilt.API.Subscriptions.Domain.Services;
using IoBuilt.API.Subscriptions.Interfaces.REST.Resources;
using IoBuilt.API.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace IoBuilt.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PlansController : ControllerBase
{
    private readonly IPlanQueryService _queryService;

    public PlansController(IPlanQueryService queryService)
    {
        _queryService = queryService;
    }

    /// <summary>
    /// Get all available subscription plans
    /// </summary>
    /// <returns>List of all plans</returns>
    [HttpGet]
    public async Task<IEnumerable<PlanResource>> GetAll()
    {
        var entities = await _queryService.Handle(new GetAllPlansQuery());
        return entities.Select(PlanResourceFromEntityAssembler.ToResource);
    }
}

