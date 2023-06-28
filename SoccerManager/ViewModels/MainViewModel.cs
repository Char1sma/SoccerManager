using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
using SoccerManager.Client.Factories;
using SoccerManager.Client.Services;
using SoccerManager.Client.Stores;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;

namespace SoccerManager.Client.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    #region Constructor

    public MainViewModel(NavigationStore navigationStore,
      LanguageService languageService,
      INavigationService homeNavigationService)
    {
      _navigationStore = navigationStore;
      _languageService = languageService;
      _homeNavigationService = homeNavigationService;

      NavigateHomeCommand = new NavigateCommand(homeNavigationService);
      CloseAppCommand = new CloseApplicationCommand();

      _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    #endregion

    #region Properties, fields

    private readonly NavigationStore _navigationStore;
    private readonly LanguageService _languageService;
    private readonly INavigationService _homeNavigationService;

    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;


    #region Localization

    public List<CultureInfo> Languages => _languageService.Languages;

    public CultureInfo SelectedLanguage
    {
      get => _languageService.CurrentLanguage;
      set
      {
        _languageService.CurrentLanguage = value;
        OnPropertyChanged(nameof(SelectedLanguage));
      }
    }

    #endregion

    #region Commands

    public ICommand NavigateHomeCommand { get; }
    public ICommand CloseAppCommand { get; }

    #endregion

    #endregion

    #region Methods, handlers

    private void OnCurrentViewModelChanged()
    {
      OnPropertyChanged(nameof(CurrentViewModel));
    }

    #endregion
  }
}
