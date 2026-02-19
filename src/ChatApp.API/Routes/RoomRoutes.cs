namespace ChatApp.Api.Routes;

public sealed class RoomRoutes : ApiBaseRoute
{
    #region Fields, Properties

    public const string Tags = "Rooms";

    public const string Base = "rooms";

    public const string GetAll = $"{ApiRoute}/{Base}/list";

    public const string GetById = $"{ApiRoute}/{Base}/{{roomId}}";

    public const string Create = $"{ApiRoute}/{Base}/create";

    public const string Update = $"{ApiRoute}/{Base}/{{roomId}}";

    public const string Delete = $"{ApiRoute}/{Base}/{{roomId}}";

    #endregion
}