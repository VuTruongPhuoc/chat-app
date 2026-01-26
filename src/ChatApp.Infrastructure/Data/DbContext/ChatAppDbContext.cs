using System.Reflection;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.DbContext;

public class ChatAppDbContext : IdentityDbContext<Users, Roles, Guid>
{
    #region Ctors

    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options) { }

    #endregion

    #region DbSets

    public DbSet<CallParticipants> CallParticipants { get; set; }
    public DbSet<CallSessions> CallSessions { get; set; }
    public DbSet<MessageFiles> MessageFiles { get; set; }
    public DbSet<Messages> Messages { get; set; }
    public DbSet<Rooms> Rooms { get; set; }
    public DbSet<RoomMembers> RoomMembers { get; set; }
    public DbSet<Reactions> Reactions { get; set; }
    public DbSet<Notifications> Notifications { get; set; }

    #endregion

    #region Methods

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName is not null)
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
        }
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #endregion
}
