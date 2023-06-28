using System;

namespace SoccerManager.Client.Common.Command
{
  public class ParameterRelayCommand<T> : CommandBase
  {
    private readonly Action<T> _callback;

    public ParameterRelayCommand(Action<T> callback)
    {
      _callback = callback;
    }

    public override void Execute(object parameter)
    {
      _callback((T)parameter);
    }
  }
}
