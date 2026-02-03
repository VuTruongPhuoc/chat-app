using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Domain.Entities;
using Common.Models.Responses;

namespace ChatApp.Domain.Repositories;

public interface IIdentityRepository
{
    #region Methods

    Task<ApiResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);

    Task<ApiResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);

    Task<ApiResponse> ForgotPasswordAsync(string Email, CancellationToken cancellationToken = default);
    
    Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken = default);

    Task<string> GenerateTokenByUser(Users user);

    #endregion
}