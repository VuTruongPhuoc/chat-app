using ChatApp.Domain.Entities;

public interface IUserRepository
{
    Task<Guid> RegisterUserAsync(Users user, CancellationToken cancellationToken);
}