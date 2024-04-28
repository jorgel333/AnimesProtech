using AnimesProtech.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimesProtech.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Anime> Animes { get; set; }
    public DbSet<Director> Directors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<Anime>().HasQueryFilter(x => x.Active);
    }
}

