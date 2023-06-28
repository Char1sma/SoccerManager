using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
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
      INavigationService homeNavigationService,
      INavigationService clubsNavigationService,
      INavigationService playersNavigationService,
      INavigationService fansNavigationService)
    {
      _navigationStore = navigationStore;
      _languageService = languageService;

      NavigateHomeCommand = new NavigateCommand(homeNavigationService);
      NavigateClubsCommand = new NavigateCommand(clubsNavigationService);
      NavigatePlayersCommand = new NavigateCommand(playersNavigationService);
      NavigateFansCommand = new NavigateCommand(fansNavigationService);
      CloseAppCommand = new CloseApplicationCommand();

      _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    #endregion

    #region Properties, fields

    private readonly NavigationStore _navigationStore;
    private readonly LanguageService _languageService;


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

    public ICommand NavigateClubsCommand { get; }
    public ICommand NavigatePlayersCommand { get; }
    public ICommand NavigateFansCommand { get; }
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
