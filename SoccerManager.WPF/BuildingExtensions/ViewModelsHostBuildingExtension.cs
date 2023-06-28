using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerManager.Client.Factories;
using SoccerManager.Client.Services;
using SoccerManager.Client.Stores;
using SoccerManager.Client.ViewModels;
using SoccerManager.WPF;

namespace SoccerManager.Client.BuildingExtensions
{
  public static class ViewModelsHostBuildingExtension
  {
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
      host.ConfigureServices(services =>
      {
        services.AddSingleton<MainViewModel>(s =>
        new MainViewModel(
          s.GetRequiredService<NavigationStore>(),
          s.GetRequiredService<LanguageService>(),
          s.GetRequiredService<INavigationService>(),
          s.GetRequiredService<NavigationServiceFactory>().CreateNavigationService<ClubsManagementViewModel>(s),
          s.GetRequiredService<NavigationServiceFactory>().CreateNavigationService<PlayersManagementViewModel>(s),
          s.GetRequiredService<NavigationServiceFactory>().CreateNavigationService<FansManagementViewModel>(s)));


        services.AddSingleton<MainWindow>(s => new MainWindow()
        {
          DataContext = s.GetRequiredService<MainViewModel>()
        });

        services.AddScoped<HomeViewModel>(s => new HomeViewModel());
        services.AddTransient<ClubsManagementViewModel>();
        services.AddTransient<PlayersManagementViewModel>();
        services.AddTransient<FansManagementViewModel>();
      });

      return host;
    }
  }
}
