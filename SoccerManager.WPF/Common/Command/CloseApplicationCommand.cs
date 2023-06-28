using System.Windows;

namespace SoccerManager.Client.Common.Command
{
  public class CloseApplicationCommand : CommandBase
  {
    public override void Execute(object? parameter)
    {
      Application.Current.MainWindow.Close();
    }
  }
}
