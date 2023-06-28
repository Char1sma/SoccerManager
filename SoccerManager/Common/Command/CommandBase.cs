using System;
using System.Windows.Input;

namespace SoccerManager.Client.Common.Command
{
  public abstract class CommandBase : ICommand
  {
    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;

    protected void OnExecuteChanged()
    {
      CanExecuteChanged?.Invoke(this, new EventArgs());
    }
  }
}
