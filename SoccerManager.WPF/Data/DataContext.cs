using Microsoft.EntityFrameworkCore;
using SoccerManager.Client.Models;

namespace SoccerManager.Client.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    #region DB sets

    public DbSet<Club> Clubs { get; set; }
    public DbSet<Fan> Fans { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<FanClub> FanClubs { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Fan>(entity =>
      {
        entity.HasKey(f => f.Id);
      });

      modelBuilder.Entity<Club>(entity =>
      {
        entity.HasKey(c => c.Id);
        entity.HasMany(c => c.Players).WithOne().OnDelete(DeleteBehavior.Cascade);
      });

      modelBuilder.Entity<Player>(entity =>
      {
        entity.HasKey(p => p.Id);
      });

      modelBuilder.Entity<FanClub>(entity =>
      {
        entity.HasKey(fc => new { fc.FanId, fc.ClubId });
        entity.HasOne(fc => fc.Fan).WithMany(f => f.FanClubs).HasForeignKey(fc => fc.FanId).OnDelete(DeleteBehavior.Cascade);
        entity.HasOne(fc => fc.Club).WithMany(c => c.FanClubs).HasForeignKey(fc => fc.ClubId).OnDelete(DeleteBehavior.Cascade);
      });
    }
  }
}
