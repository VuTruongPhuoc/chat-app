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

        builder.Entity<RoomMembers>(entity =>
        {
            entity.HasKey(rm => new { rm.UserId, rm.RoomId });

            entity.HasOne(rm => rm.User)
                .WithMany(u => u.RoomMembers) 
                .HasForeignKey(rm => rm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(rm => rm.Room)
                .WithMany(r => r.Members)
                .HasForeignKey(rm => rm.RoomId)
                .OnDelete(DeleteBehavior.Cascade); 
        });

        builder.Entity<Messages>(entity =>
        {
            entity.HasOne(m => m.Room)
                .WithMany(r => r.Messages)
                .HasForeignKey(m => m.RoomId)
                .OnDelete(DeleteBehavior.Cascade); 

            entity.HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); 
        });

        builder.Entity<MessageFiles>(entity =>
        {
            entity.HasOne(mf => mf.Message)
                .WithMany() 
                .HasForeignKey(mf => mf.MessageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Reactions>(entity =>
        {
            entity.HasOne(r => r.Message)
                .WithMany() 
                .HasForeignKey(r => r.MessageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Friendship>(entity =>
        {
            entity.HasKey(f => new { f.UserId, f.FriendId });

            entity.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(f => f.Friend)
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Notifications>(entity =>
        {
            entity.HasOne(n => n.Receiver)
                .WithMany()
                .HasForeignKey(n => n.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #endregion
}
