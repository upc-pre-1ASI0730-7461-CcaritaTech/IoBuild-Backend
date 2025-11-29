using System.Net.Mime;
using IoBuilt.API.Clients.Domain.Model.Commands;
using IoBuilt.API.Clients.Domain.Model.Queries;
using IoBuilt.API.Clients.Domain.Services;
using IoBuilt.API.Clients.Interfaces.REST.Resources;
using IoBuilt.API.Clients.Interfaces.REST.Transform;
using IoBuilt.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IoBuilt.API.Clients.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Client Endpoints.")]
public class ClientsController(IClientQueryService clientQueryService, IClientCommandService clientCommandService) : ControllerBase
{
    [HttpGet("{clientId:int}")]
    [SwaggerOperation("Get Client by Id", "Get a client by its unique identifier.", OperationId = "GetClientById")]
    [SwaggerResponse(200, "The client was found and returned.", typeof(ClientResource))]
    [SwaggerResponse(404, "The client was not found.")]
    public async Task<IActionResult> GetClientById(int clientId)
    {
        var getClientByIdQuery = new GetClientByIdQuery(clientId);
        var client = await clientQueryService.Handle(getClientByIdQuery);
        if (client is null) return NotFound();
        var clientResource = ClientResourceFromEntityAssembler.ToResourceFromEntity(client);
        return Ok(clientResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Clients", "Get all clients, optionally filtered by project ID or account statement.", OperationId = "GetAllClients")]
    [SwaggerResponse(200, "The clients were found and returned.", typeof(IEnumerable<ClientResource>))]
    public async Task<IActionResult> GetAllClients([FromQuery] int? projectId = null, [FromQuery] string? accountStatement = null)
    {
        // If no filters, return all clients
        if (projectId is null && accountStatement is null)
        {
            var getAllClientsQuery = new GetAllClientsQuery();
            var allClients = await clientQueryService.Handle(getAllClientsQuery);
            var allClientResources = allClients.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(allClientResources);
        }

        // If only projectId filter is provided
        if (projectId is not null)
        {
            var getClientsByProjectIdQuery = new GetClientsByProjectIdQuery(projectId.Value);
            var clients = await clientQueryService.Handle(getClientsByProjectIdQuery);
            var clientResources = clients.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(clientResources);
        }

        // If only accountStatement filter is provided
        if (accountStatement is not null)
        {
            try
            {
                var statement = Enum.Parse<IoBuilt.API.Clients.Domain.Model.ValueObjects.EAccountStatement>(accountStatement);
                var getClientsByAccountStatementQuery = new GetClientsByAccountStatementQuery(statement);
                var clients = await clientQueryService.Handle(getClientsByAccountStatementQuery);
                var clientResources = clients.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);
                return Ok(clientResources);
            }
            catch (ArgumentException)
            {
                return BadRequest($"Invalid account statement: {accountStatement}");
            }
        }

        return Ok(new List<ClientResource>());
    }

    [HttpPost]
    [SwaggerOperation("Create a new Client", "Creates a new client.", OperationId = "CreateClient")]
    [SwaggerResponse(201, "Client created.", typeof(ClientResource))]
    [SwaggerResponse(400, "The request is invalid.")]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientResource resource)
    {
        try
        {
            var createClientCommand = CreateClientCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await clientCommandService.Handle(createClientCommand);
            if (result is null) return BadRequest();
            var clientResource = ClientResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(GetClientById), new { clientId = clientResource.Id }, clientResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{clientId:int}")]
    [SwaggerOperation("Update Client", "Updates an existing client.", OperationId = "UpdateClient")]
    [SwaggerResponse(200, "Client updated.", typeof(ClientResource))]
    [SwaggerResponse(400, "The request is invalid.")]
    [SwaggerResponse(404, "The client was not found.")]
    public async Task<IActionResult> UpdateClient(int clientId, [FromBody] UpdateClientResource resource)
    {
        try
        {
            var updateClientCommand = UpdateClientCommandFromResourceAssembler.ToCommandFromResource(resource, clientId);
            var result = await clientCommandService.Handle(updateClientCommand);
            if (result is null) return BadRequest("Failed to update client.");
            var clientResource = ClientResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(clientResource);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not found"))
                return NotFound("Client not found.");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{clientId:int}")]
    [SwaggerOperation("Delete Client", "Deletes an existing client.", OperationId = "DeleteClient")]
    [SwaggerResponse(204, "Client deleted.")]
    [SwaggerResponse(404, "The client was not found.")]
    [SwaggerResponse(400, "The request is invalid.")]
    public async Task<IActionResult> DeleteClient(int clientId)
    {
        try
        {
            var deleteClientCommand = new DeleteClientCommand(clientId);
            var result = await clientCommandService.Handle(deleteClientCommand);
            if (!result) return BadRequest("Failed to delete client.");
            return NoContent();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not found"))
                return NotFound("Client not found.");
            return BadRequest(ex.Message);
        }
    }
}