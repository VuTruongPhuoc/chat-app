namespace ChatApp.Application.Dtos.Emails;

public static class EmailMessage
{
    public static (string Subject, string Body) ResetPassword(string link)
        => (
            "Reset Password",
            $"Click the link below to reset your password: {link}"
        );
    public static (string Subject, string Body) EmailVerification(string link)
        => (
            "Email Verification",
            $"Click the link below to verify your email: {link}"
        );
}