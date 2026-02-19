namespace ChatApp.Api.Routes;

public sealed class MessageRoutes : ApiBaseRoute
{
    #region Fields, Properties

    public const string Tags = "Messages";

    public const string Base = "messages";

    public const string Get = $"{ApiRoute}/{Base}/{{messageId}}";

    public const string Create = $"{ApiRoute}/{Base}/create";

    public const string Update = $"{ApiRoute}/{Base}/{{messageId}}";

    public const string Delete = $"{ApiRoute}/{Base}/{{messageId}}";

    #endregion
}