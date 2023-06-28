using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SoccerManager.Client.Common;
using SoccerManager.Client.Services;
using SoccerManager.Client.Stores;
using SoccerManager.Client.ViewModels;

namespace SoccerManager.Client.Factories
{
  public class NavigationServiceFactory
  {
    #region Factory methods

    public INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider) =>
      new NavigationService<HomeViewModel>(
        serviceProvider.GetRequiredService<NavigationStore>(),
        () => serviceProvider.GetRequiredService<HomeViewModel>());

    public INavigationService CreateNavigationService<TViewModel>(IServiceProvider serviceProvider)
      where TViewModel : ViewModelBase =>
      new NavigationService<TViewModel>(
        serviceProvider.GetRequiredService<NavigationStore>(),
        () => serviceProvider.GetRequiredService<TViewModel>());

    #endregion
  }
}
