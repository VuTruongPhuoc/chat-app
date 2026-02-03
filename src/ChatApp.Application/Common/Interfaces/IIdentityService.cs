using ChatApp.Application.Dtos.Auths.Requests;
using Common.Models.Responses;

namespace ChatApp.Domain.Services;

public interface IIdentityService
{
    #region Methods

    Task<ApiResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);

    Task<ApiResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);

    Task<ApiResponse> ForgotPasswordAsync(string email, CancellationToken cancellationToken = default);
    
    Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken = default);

    Task<bool> EmailVerificationAsync(EmailVerificationRequest request, CancellationToken cancellationToken = default);

    #endregion
}