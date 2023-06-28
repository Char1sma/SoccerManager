using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerManager.Client.BuildingExtensions;
using SoccerManager.Client.Factories;
using SoccerManager.Client.Services;
using SoccerManager.WPF;

namespace SoccerManager.Client
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public static IHostBuilder CreateHostBuilder(string[] args = null)
    {
      return Host.CreateDefaultBuilder(args)
        .AddConfiguration()
        .AddDataContext()
        .AddDataRepositories()
        .AddFactories()
        .AddServices()
        .AddStores()
        .AddViewModels();

    }

    private readonly IHost _host;

    public App()
    {
      _host = CreateHostBuilder().Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      _host.Start();
      _host.Services.GetRequiredService<LanguageService>().RefreshCurrentLanguage();

      var contextFactory = _host.Services.GetRequiredService<DbContextFactory>();

      using (var context = contextFactory.CreateDbContext())
      {
        context.Database.Migrate();
      }

      _host.Services.GetRequiredService<INavigationService>().Navigate();
      MainWindow = _host.Services.GetRequiredService<MainWindow>();
      MainWindow.Show();

      base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
      await _host.StopAsync();
      _host.Dispose();
      base.OnExit(e);

    }
  }
}
