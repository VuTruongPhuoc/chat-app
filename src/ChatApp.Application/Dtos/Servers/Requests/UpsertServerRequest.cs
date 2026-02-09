namespace ChatApp.Application.Dtos.Servers.Requests;

public class UpsertServerRequest
{
    #region Fields, Properties

    public string Name { get; set; } = default!;

    public string? Metadata { get; set; }

    #endregion
}
