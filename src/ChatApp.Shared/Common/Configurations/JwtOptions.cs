namespace Common.Configurations;

public sealed class JwtOptions
{
    #region Fields, Properties

    public const string Section = "JWT";

    public string Secret { get; set; } = default!;

    public string ValidAudience { get; set; } = default!;

    public string ValidIssuer { get; set; } = default!;

    #endregion
}