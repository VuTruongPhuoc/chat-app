using ChatApp.Domain.Entities;

public interface IUserRepository
{
    #region Methods

    Task<Guid> RegisterUserAsync(Users user, CancellationToken cancellationToken);

    #endregion
}