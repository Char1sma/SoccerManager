using System;
using System.Linq;
using SoccerManager.Client.Common;
using SoccerManager.Client.Helpers;
using SoccerManager.Client.Models;
using SoccerManager.Client.Validators;

namespace SoccerManager.Client.ViewModels.ModalContext
{
  public class PlayerAdditionViewModel : ModalDialogViewModelBase
  {
    #region Properties and fields

    private readonly PlayerValidator _playerValidator = new PlayerValidator();
    public string Name { get; set; }
    public string Snils { get; set; }
    public DateTime BirthDate { get; set; }

    #endregion

    public override object SetResult()
    {
      var player =  new Player()
      {
        Name = Name,
        BirthDate = BirthDate,
        Snils = Snils
      };


      ClearErrors();

      var validationResult = _playerValidator.Validate(player);

      if (!validationResult.Errors.Any())
        return player;

      foreach (var error in validationResult.Errors)
      {
        AddError(error.PropertyName, error.ErrorMessage);
      }

      ModalWindowHelper.ShowMessage("CheckInput");

      return null;
    }


    public PlayerAdditionViewModel()
    {
      BirthDate = DateTime.Today;
    }

  }
}
