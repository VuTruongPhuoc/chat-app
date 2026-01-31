using ChatApp.Domain.Entities;
using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.DbContext;

namespace ChatApp.Infrastructure.Repositories;

public class MessageRepository : Repository<Messages>, IMessageRepository
{
    #region Ctor

    public MessageRepository(ChatAppDbContext context) : base(context)
    {
    }

    #endregion
}