namespace ChatApp.Application.Dtos.Servers.Responses;

public sealed class ServerResponse
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid OwnerId { get; set; }

    public string? Metadata { get; set; }
}
