using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerManager.Client.Stores;

namespace SoccerManager.Client.BuildingExtensions
{
  public static class StoresHostBuildingExtension
  {
    public static IHostBuilder AddStores(this IHostBuilder host)
    {
      host.ConfigureServices((context, services) =>
      {
        services.AddSingleton<NavigationStore>();
        services.AddSingleton<LanguageStore>();
      });

      return host;
    }
  }
}
