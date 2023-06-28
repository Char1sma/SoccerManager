using Microsoft.Extensions.DependencyInjection;
using SoccerManager.Client.Factories;
using SoccerManager.Client.Services;
using SoccerManager.Client.Stores;
using SoccerManager.Client.ViewModels;
using System;
using System.Windows;

namespace SoccerManager.Client
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private readonly IServiceProvider _serviceProvider;

    public App()
    {
      IServiceCollection services = new ServiceCollection();

      //Factories
      services.AddSingleton<NavigationServiceFactory>();
      services.AddSingleton<LanguageFactory>();

      //Stores
      services.AddSingleton<NavigationStore>();
      services.AddSingleton<LanguageStore>();

      //Services
      services.AddSingleton<LanguageService>();
      services.AddScoped<INavigationService>(s => 
        s.GetRequiredService<NavigationServiceFactory>().CreateNavigationService<HomeViewModel>(s));

      //View-Models
      services.AddSingleton<MainViewModel>(s => 
        new MainViewModel(
          s.GetRequiredService<NavigationStore>(),
          s.GetRequiredService<LanguageService>(),
          s.GetRequiredService<INavigationService>()));


      services.AddSingleton<MainWindow>(s => new MainWindow()
      {
        DataContext = s.GetRequiredService<MainViewModel>()
      });


      //Presentation View-Models
      services.AddTransient<HomeViewModel>(s => new HomeViewModel());


      _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      _serviceProvider.GetRequiredService<LanguageService>().RefreshCurrentLanguage();
      _serviceProvider.GetRequiredService<INavigationService>().Navigate();

      MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
      MainWindow.Show();

      base.OnStartup(e);
    }

  }
}
