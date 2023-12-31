﻿using SoccerManager.Client.Common;
using SoccerManager.Client.Stores;
using System;

namespace SoccerManager.Client.Services
{
  public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
    }

    public void Navigate()
    {
      _navigationStore.CurrentViewModel = _createViewModel();
    }
  }
}
