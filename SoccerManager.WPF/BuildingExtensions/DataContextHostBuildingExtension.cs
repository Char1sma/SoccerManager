using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerManager.Client.Data;
using SoccerManager.Client.Factories;
using System;

namespace SoccerManager.Client.BuildingExtensions
{
  public static class DataContextHostBuildingExtension
  {
    public static IHostBuilder AddDataContext(this IHostBuilder host)
    {
      host.ConfigureServices((context, services) =>
      {
        var connectionString = context.Configuration.GetConnectionString("sqlite");
        Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

        services.AddDbContext<DataContext>(configureDbContext);
        services.AddSingleton<DbContextFactory>(new DbContextFactory(configureDbContext));
      });

      return host;
    }
  }
}
