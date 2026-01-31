namespace ChatApp.Api.Routes;

public sealed class RoomRoutes : ApiBaseRoute
{
    #region Fields, Properties

    public const string Tags = "Rooms";

    public const string Base = "room";

    public const string Get = $"{ApiRoute}/{Base}/get";

    public const string Create = $"{ApiRoute}/{Base}/create";

    public const string Update = $"{ApiRoute}/{Base}/update";

    public const string Delete = $"{ApiRoute}/{Base}/delete";

    #endregion
}