using EFTestCodeFirst.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFTestCodeFirst.DAL;

public sealed class ApplicationContext: DbContext
{
    public DbSet<UserDb> Users => Set<UserDb>();
    public DbSet<CharacterDb> Characters => Set<CharacterDb>();
    public DbSet<GuildDb> Guilds => Set<GuildDb>();

    public ApplicationContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=app;Password=test");
    }
}