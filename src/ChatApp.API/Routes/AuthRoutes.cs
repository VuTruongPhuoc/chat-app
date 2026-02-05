namespace ChatApp.Api.Routes;

public sealed class AuthRoutes : ApiBaseRoute
{
    #region Routes Constants 

    public const string Tags = "Auths";

    public const string Base = "auth";

    public const string Login = $"/{ApiRoute}/{Base}/login";

    public const string Register = $"/{ApiRoute}/{Base}/register";

    public const string GoogleLogin = $"/{ApiRoute}/{Base}/google-login";

    public const string ForgotPassword = $"/{ApiRoute}/{Base}/forgot-password";

    public const string ResetPassword = $"/{ApiRoute}/{Base}/reset-password";

    public const string ResentVerificationEmail = $"/{ApiRoute}/{Base}/resent-verification-email";

    public const string VerifyEmail = $"/{ApiRoute}/{Base}/verify-email";

    #endregion
}