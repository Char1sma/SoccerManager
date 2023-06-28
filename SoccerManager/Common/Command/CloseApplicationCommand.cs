using System;

namespace SoccerManager.Client.Common.Command
{
  public class CloseApplicationCommand : CommandBase
  {
    public override void Execute(object? parameter)
    {
      Environment.Exit(0);
    }
  }
}
