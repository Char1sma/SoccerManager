using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerManager.Client.Data.Repositories;

namespace SoccerManager.Client.BuildingExtensions
{
    public static class DataRepositoriesHostBuildingExtension
    {
      public static IHostBuilder AddDataRepositories(this IHostBuilder host)
      {
        host.ConfigureServices((context, services) =>
        {
          services.AddSingleton<IClubsRepository, ClubsRepository>();
          services.AddSingleton<IFansRepository, FansRepository>();
          services.AddSingleton<IPlayersRepository, PlayersRepository>();
        });

        return host;
      }
  }
}
