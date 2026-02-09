using ChatApp.Domain.Entities;
using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.DbContext;

namespace ChatApp.Infrastructure.Repositories;

public class ServerRepository : Repository<Servers>, IServerRepository
{
    #region Ctor

    public ServerRepository(ChatAppDbContext context) : base(context)
    {
    }

    #endregion
}
