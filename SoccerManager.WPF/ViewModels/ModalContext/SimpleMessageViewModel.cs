using SoccerManager.Client.Common;
using SoccerManager.Client.Helpers;

namespace SoccerManager.Client.ViewModels.ModalContext
{
  public class SimpleMessageViewModel : ViewModelBase
  {
    public string Message { get; set; }

    public SimpleMessageViewModel(string caption)
    {
      Message = ResourceHelper.GetResource(caption);
    }
  }
}
