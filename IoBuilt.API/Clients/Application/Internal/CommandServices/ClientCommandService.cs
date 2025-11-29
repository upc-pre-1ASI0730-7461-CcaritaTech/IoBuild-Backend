using IoBuilt.API.Clients.Domain.Model.Aggregates;
using IoBuilt.API.Clients.Domain.Model.Commands;
using IoBuilt.API.Clients.Domain.Repositories;
using IoBuilt.API.Clients.Domain.Services;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Clients.Application.Internal.CommandServices;

public class ClientCommandService(
    IClientRepository clientRepository,
    IUnitOfWork unitOfWork) : IClientCommandService
{
    public async Task<Client?> Handle(CreateClientCommand command)
    {
        var existingClient = await clientRepository.FindByEmailAsync(command.Email);
        if (existingClient is not null) throw new Exception("Client with this email already exists.");

        var client = new Client(command);
        try
        {
            await clientRepository.AddAsync(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
        return client;
    }

    public async Task<Client?> Handle(UpdateClientCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.Id);
        if (client is null) throw new Exception("Client not found.");
        
        // Check if email is being changed and if it's already in use
        if (client.Email != command.Email)
        {
            var existingClient = await clientRepository.FindByEmailAsync(command.Email);
            if (existingClient is not null) throw new Exception("Another client with this email already exists.");
        }

        client.UpdateContactInformation(command.Email, command.PhoneNumber, command.Address);
        client.UpdateProjectAssignment(command.ProjectId, command.ProjectName);
        client.UpdateAccountStatement(command.AccountStatement);
        
        try
        {
            clientRepository.Update(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
        return client;
    }

    public async Task<bool> Handle(DeleteClientCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.Id);
        if (client is null) throw new Exception("Client not found.");
        
        try
        {
            clientRepository.Remove(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
        return true;
    }
}
