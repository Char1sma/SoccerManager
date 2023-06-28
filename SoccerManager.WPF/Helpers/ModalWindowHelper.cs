using SoccerManager.Client.Common;
using SoccerManager.Client.Controls;
using SoccerManager.Client.ViewModels.ModalContext;

namespace SoccerManager.Client.Helpers
{
  public static class ModalWindowHelper
  {
    public static ModalWindow ShowDialog(ModalDialogViewModelBase context)
    {
      var window = new ModalWindow()
      {
        Context = context
      };
      window.ShowDialog();

      return window;
    }

    public static ModalMessageBox ShowWindow(ViewModelBase context)
    {
      var window = new ModalMessageBox()
      {
        Context = context
      };
      window.ShowDialog();

      return window;
    }

    public static void ShowMessage(string caption)
    {
      ShowWindow(new SimpleMessageViewModel(caption));
    }
  }
}
