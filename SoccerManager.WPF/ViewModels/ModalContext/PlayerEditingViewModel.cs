using System.Collections.Generic;
using System.Windows.Input;
using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
using SoccerManager.Client.Models;
using SoccerManager.Client.Validators;
using System.Linq;
using SoccerManager.Client.Helpers;

namespace SoccerManager.Client.ViewModels.ModalContext
{
  public class PlayerEditingViewModel : ModalDialogViewModelBase
  {
    #region Properties and fields

    private readonly PlayerValidator _playerValidator = new PlayerValidator();
    public Player Player { get; set; }

    public List<Club> Clubs { get; set; }

    public ICommand NullifyClubSelectionCommand { get; set; }

    #endregion

    public PlayerEditingViewModel(Player player, IEnumerable<Club> clubs)
    {
      Player = player;
      Clubs = new List<Club>(clubs);
      NullifyClubSelectionCommand = new RelayCommand(NullifyClubSelection);
    }

    private void NullifyClubSelection()
    {
      Player.Club = null;
      OnPropertyChanged(nameof(Player.Club));
    }

    public override object SetResult()
    {
      ClearErrors();

      var validationResult = _playerValidator.Validate(Player);

      if (!validationResult.Errors.Any())
        return Player;

      foreach (var error in validationResult.Errors)
      {
        AddError(error.PropertyName, error.ErrorMessage);
      }

      ModalWindowHelper.ShowMessage("CheckInput");

      return null;
    }
  }
}
