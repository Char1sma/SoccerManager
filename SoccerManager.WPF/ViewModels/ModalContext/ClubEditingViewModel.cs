using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
using SoccerManager.Client.Helpers;
using SoccerManager.Client.Models;
using SoccerManager.Client.Validators;

namespace SoccerManager.Client.ViewModels.ModalContext
{
  public class ClubEditingViewModel : ModalDialogViewModelBase
  {
    #region Properties and fields

    private readonly ClubValidator _clubValidator = new ClubValidator();

    private readonly IEnumerable<Player> _allPlayers;

    public ObservableCollection<Player> CurrentPlayers { get; set; }
    public ObservableCollection<Player> PlayersToAdd { get; set; }
    public Player SelectedPlayer { get; set; }
    public Player SelectedPlayerToAdd { get; set; }
    public Club Club { get; set; }

    #region Commands

    public ICommand AddPlayerCommand { get; set; }
    public ICommand DeletePlayerCommand { get; set; }

    #endregion



    #endregion

    public ClubEditingViewModel(Club club, IEnumerable<Player> allPlayers)
    {
      _allPlayers = allPlayers;
      CurrentPlayers = new ObservableCollection<Player>(_allPlayers.Where(p => p.Club == club));
      PlayersToAdd = new ObservableCollection<Player>(_allPlayers.Where(p => p.Club != club));
      Club = club;

      AddPlayerCommand = new RelayCommand(AddPlayer);
      DeletePlayerCommand = new RelayCommand(DeletePlayer);
    }


    #region Methods

    public override object SetResult()
    {
      ClearErrors();

      var validationResult = _clubValidator.Validate(Club);

      if (!validationResult.Errors.Any())
        return Club;

      foreach (var error in validationResult.Errors)
      {
        AddError(error.PropertyName, error.ErrorMessage);
      }

      ModalWindowHelper.ShowMessage("CheckInput");

      return null;
    }

    private void AddPlayer()
    {
      if (SelectedPlayerToAdd != null)
      {
        SelectedPlayer.Club = Club;
        CurrentPlayers.Add(SelectedPlayerToAdd);
        PlayersToAdd.Remove(SelectedPlayerToAdd);
        SelectedPlayerToAdd = null;
        OnPropertyChanged(nameof(SelectedPlayerToAdd));
      }
    }

    private void DeletePlayer()
    {
      if (SelectedPlayer != null)
      {
        SelectedPlayer.Club = null;
        PlayersToAdd.Add(SelectedPlayer);
        CurrentPlayers.Remove(SelectedPlayer);
      }
    }

    #endregion
  }
}
