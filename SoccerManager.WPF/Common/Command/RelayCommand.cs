using System;

namespace SoccerManager.Client.Common.Command
{
  public class RelayCommand : CommandBase
  {
    public RelayCommand(Action callback)
    {
      _callback = callback;
    }

    private readonly Action _callback;
    public override void Execute(object parameter)
    {
      _callback();
    }
  }
}
