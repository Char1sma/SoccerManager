using SoccerManager.Client.Common;
using SoccerManager.Client.Models;

namespace SoccerManager.Client.ViewModels.ModalContext
{
  public class FanAdditionViewModel : ModalDialogViewModelBase
  {
    #region Properties and fields

    public string Name { get; set; }

    #endregion
    public override object SetResult() =>
      new Fan()
      {
        Name = Name
      };
  }
}
