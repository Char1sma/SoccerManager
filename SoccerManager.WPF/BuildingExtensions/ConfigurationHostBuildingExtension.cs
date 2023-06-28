using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SoccerManager.Client.BuildingExtensions
{
  public static class ConfigurationHostBuildingExtension
  {
    public static IHostBuilder AddConfiguration(this IHostBuilder host)
    {
      host.ConfigureAppConfiguration(c =>
      {
        c.AddJsonFile("appsettings.json");
        c.AddEnvironmentVariables();
      });

      return host;
    }
  }
}
