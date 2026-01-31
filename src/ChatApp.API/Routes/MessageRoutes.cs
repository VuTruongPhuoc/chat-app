namespace ChatApp.Api.Routes;

public sealed class MessageRoutes : ApiBaseRoute
{
    #region Fields, Properties

    public const string Tags = "Messages";

    public const string Base = "message";

    public const string Get = $"{ApiRoute}/{Base}/get";

    public const string Create = $"{ApiRoute}/{Base}/create";

    public const string Update = $"{ApiRoute}/{Base}/update";

    public const string Delete = $"{ApiRoute}/{Base}/delete";

    #endregion
}