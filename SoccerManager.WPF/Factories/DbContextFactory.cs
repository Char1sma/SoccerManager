using Microsoft.EntityFrameworkCore;
using SoccerManager.Client.Data;
using System;

namespace SoccerManager.Client.Factories
{
  public class DbContextFactory
  {
    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    public DbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
    {
      _configureDbContext = configureDbContext;
    }

    public DataContext CreateDbContext()
    {
      var options = new DbContextOptionsBuilder<DataContext>();
      _configureDbContext(options);

      return new DataContext(options.Options);
    }
  }
}
