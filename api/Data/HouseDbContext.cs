using Globomantics.Models;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Data;

public class HouseDbContext : DbContext
{
  public DbSet<House> Houses => Set<House>();
  public DbSet<Bid> Bids => Set<Bid>();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);

    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);

    optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "houses.db")}");
    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    SeedData.Seed(modelBuilder);
  }
}