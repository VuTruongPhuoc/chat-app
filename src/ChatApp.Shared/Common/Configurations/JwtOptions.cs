namespace Common.Configurations;

public sealed class JwtOptions
{
    #region Fields, Properties

    public const string Section = "JWTSettings";

    public string Secret { get; set; } = default!;

    public string ValidAudience { get; set; } = default!;

    public string ValidIssuer { get; set; } = default!;

    public int AccessTokenExpirationMinutes { get; set; } = default!;

    #endregion
}