using System.Collections.Generic;
using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
using SoccerManager.Client.Data.Repositories;
using SoccerManager.Client.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SoccerManager.Client.Helpers;
using SoccerManager.Client.ViewModels.ModalContext;

namespace SoccerManager.Client.ViewModels
{
  public class PlayersManagementViewModel : ViewModelBase
  {
    #region Properties and fields

    #region Commands

    public ICommand AddPlayerCommand { get; set; }
    
    public ICommand DeletePlayerCommand { get; set; }

    public ICommand EditPlayerCommand { get; set; }
    

    #endregion

    private readonly IPlayersRepository _playersRepository;
    private readonly IEnumerable<Club> _clubs;

    public ObservableCollection<Player> Players { get; set; }
    

    #endregion

    public PlayersManagementViewModel(IPlayersRepository playersRepository,
      IClubsRepository clubsRepository)
    {
      _playersRepository = playersRepository;
      _clubs = clubsRepository.GetAll();

      Players = new ObservableCollection<Player>(_playersRepository.GetAll());

      AddPlayerCommand = new RelayCommand(AddPlayer);
      DeletePlayerCommand = new ParameterRelayCommand<Player>(DeletePlayer);
      EditPlayerCommand = new ParameterRelayCommand<Player>(EditPlayer);
    }

    #region Methods

    private void EditPlayer(Player player)
    {
      var context = new PlayerEditingViewModel(player, _clubs);
      var dialog = ModalWindowHelper.ShowDialog(context);

      if (dialog.Result != null)
      {
        _playersRepository.Save();
      }
    }

    private void DeletePlayer(Player player)
    {
      _playersRepository.Delete(player);
    }

    private void AddPlayer()
    {
      var context = new PlayerAdditionViewModel();
      var dialog = ModalWindowHelper.ShowDialog(context);

      if (dialog.Result != null)
      {
        var player = dialog.Result as Player;
        Players.Add(player);
        _playersRepository.Create(player);
      }
    }

    #endregion
  }
}
