using ChatApp.Application.Dtos.Users;
using Common.Models.Responses;

namespace ChatApp.Domain.Repositories;

public interface IIdentityRepository
{
    #region Methods

    Task<ApiResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);

    Task<ApiResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);

    #endregion
}