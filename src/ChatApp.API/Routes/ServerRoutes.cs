namespace ChatApp.Api.Routes;

public sealed class ServerRoutes : ApiBaseRoute
{
    #region Fields, Properties

    public const string Tags = "Servers";

    public const string Base = "servers";

    public const string GetAll = $"{ApiRoute}/{Base}/list";

    public const string GetById = $"{ApiRoute}/{Base}/{{serverId}}";

    public const string Create = $"{ApiRoute}/{Base}/create";

    public const string Update = $"{ApiRoute}/{Base}/{{serverId}}";

    public const string Delete = $"{ApiRoute}/{Base}/{{serverId}}";

    #endregion
}
