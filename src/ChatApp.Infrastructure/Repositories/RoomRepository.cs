using ChatApp.Domain.Entities;
using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.DbContext;

namespace ChatApp.Infrastructure.Repositories;

public class RoomRepository : Repository<Rooms>, IRoomRepository
{
    #region Ctor

    public RoomRepository(ChatAppDbContext context) : base(context)
    {
    }

    #endregion
}