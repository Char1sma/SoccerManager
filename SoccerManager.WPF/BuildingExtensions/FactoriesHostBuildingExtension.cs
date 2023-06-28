using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerManager.Client.Factories;

namespace SoccerManager.Client.BuildingExtensions
{
  public static class FactoriesHostBuildingExtension
  {
    public static IHostBuilder AddFactories(this IHostBuilder host)
    {
      host.ConfigureServices((context, services) =>
      {
        services.AddSingleton<NavigationServiceFactory>();
        services.AddSingleton<LanguageFactory>();
      });

      return host;
    }
  }
}
