using System;
using IoBuilt.API.Clients.Domain.Model.Commands;
using IoBuilt.API.Clients.Domain.Model.ValueObjects;

namespace IoBuilt.API.Clients.Domain.Model.Aggregates;

public partial class Client
{
    public int Id { get; }
    public string FullName { get; private set; }
    public int ProjectId { get; private set; }
    public string ProjectName { get; private set; }
    public EAccountStatement AccountStatement { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }

    public Client()
    {
        FullName = string.Empty;
        ProjectName = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        AccountStatement = EAccountStatement.Pending;
    }
    
    public Client(string fullName, int projectId, string projectName, EAccountStatement accountStatement, 
                  string email, string phoneNumber, string address)
    {
        FullName = fullName;
        ProjectId = projectId;
        ProjectName = projectName;
        AccountStatement = accountStatement;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public Client(CreateClientCommand command)
    {
        FullName = command.FullName;
        ProjectId = command.ProjectId;
        ProjectName = command.ProjectName;
        AccountStatement = command.AccountStatement;
        Email = command.Email;
        PhoneNumber = command.PhoneNumber;
        Address = command.Address;
    }

    public void UpdateAccountStatement(EAccountStatement accountStatement)
    {
        AccountStatement = accountStatement;
    }
    
    public void UpdateProjectAssignment(int projectId, string projectName)
    {
        ProjectId = projectId;
        ProjectName = projectName;
    }
    
    public void UpdateContactInformation(string email, string phoneNumber, string address)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }
    
    public void UpdateFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name cannot be empty or whitespace", nameof(fullName));
        
        FullName = fullName;
    }
    
    public bool IsActive => AccountStatement == EAccountStatement.Active;
    
    public bool HasProjectAssigned => ProjectId > 0;
}
