using System.Linq;
using SoccerManager.Client.Common;
using SoccerManager.Client.Helpers;
using SoccerManager.Client.Models;
using SoccerManager.Client.Validators;

namespace SoccerManager.Client.ViewModels.ModalContext
{
  public class ClubAdditionViewModel : ModalDialogViewModelBase
  {
    private readonly ClubValidator _clubValidator = new ClubValidator();
    public string Name { get; set; }
    public string City { get; set; }
    public override object SetResult()
    {
      ClearErrors();

      var club = new Club()
      {
        City = City,
        Name = Name
      };

      var validationResult = _clubValidator.Validate(club);

      if (!validationResult.Errors.Any())
        return club;

      foreach (var error in validationResult.Errors)
      {
        AddError(error.PropertyName, error.ErrorMessage);
      }

      ModalWindowHelper.ShowMessage("CheckInput");

      return null;
    }
  }
}
