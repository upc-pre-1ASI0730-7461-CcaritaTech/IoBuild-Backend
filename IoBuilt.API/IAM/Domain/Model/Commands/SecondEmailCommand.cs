namespace IoBuilt.API.IAM.Domain.Model.Commands;

public record SecondEmailCommand(int UserId, string? SecondEmail);