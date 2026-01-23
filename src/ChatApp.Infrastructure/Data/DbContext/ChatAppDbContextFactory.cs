using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChatApp.Infrastructure.DbContext;

public class ChatAppDbContextFactory
    : IDesignTimeDbContextFactory<ChatAppDbContext>
{
    public ChatAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ChatAppDbContext>();

        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Database=chatdb;Username=postgres;Password=772002"
        );

        return new ChatAppDbContext(optionsBuilder.Options);
    }
}
