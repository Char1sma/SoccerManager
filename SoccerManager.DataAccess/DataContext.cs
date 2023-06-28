using Microsoft.EntityFrameworkCore;
using SoccerManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerManager.DataAccess
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    #region DB sets

    public DbSet<Club> Clubs { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Fan> Fans { get; set; }

    public DbSet<FanClub> FanClubs { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<FanClub>().HasKey(fc => new { fc.FanId, fc.ClubId });
      modelBuilder.Entity<FanClub>().HasOne(fc => fc.Fan).WithMany(f => f.FanClubs).HasForeignKey(fc => fc.FanId);
      modelBuilder.Entity<FanClub>().HasOne(fc => fc.Club).WithMany(c => c.FanClubs).HasForeignKey(fc => fc.ClubId);
    }
  }
}
