namespace Common.Configurations;

public sealed class FrontEndOptions
{
    #region Fields, Properties

    public const string Section = "FrontEndSettings";

    public static string BaseUrl = "BaseUrl";

    public string ResetPasswordPath = "ResetPasswordPath";

    public string ResentVerificationEmailPath = "ResentVerificationEmailPath";

    #endregion

    #region Methods

    public static string BuildLink(string path, string email, string token)
        => $"{BaseUrl}{path}?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}";
    
    #endregion
}