using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerManager.Client.Factories;
using SoccerManager.Client.Services;
using SoccerManager.Client.ViewModels;

namespace SoccerManager.Client.BuildingExtensions
{
  public static class ServicesHostBuildingExtension
  {
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
      host.ConfigureServices((context, services) =>
      {
        services.AddSingleton<LanguageService>();
        services.AddScoped<INavigationService>(s =>
          s.GetRequiredService<NavigationServiceFactory>().CreateNavigationService<HomeViewModel>(s));
      });

      return host;
    }
  }
}
