﻿using SoccerManager.Client.Common;
using System;

namespace SoccerManager.Client.Stores
{
  public class NavigationStore
  {
    private ViewModelBase _currentViewModel;

    public ViewModelBase CurrentViewModel
    {
      get => _currentViewModel;
      set
      {
        _currentViewModel?.Dispose();
        _currentViewModel = value;
        OnCurrentViewModelChanged();
      }
    }

    public event Action CurrentViewModelChanged;

    private void OnCurrentViewModelChanged()
    {
      CurrentViewModelChanged?.Invoke();
    }
  }
}
