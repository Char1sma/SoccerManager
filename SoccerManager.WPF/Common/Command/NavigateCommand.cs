using SoccerManager.Client.Services;

namespace SoccerManager.Client.Common.Command
{
  public class NavigateCommand : CommandBase
  {
    private readonly INavigationService _navigationService;

    public NavigateCommand(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }


    public override void Execute(object? parameter)
    {
      _navigationService.Navigate();
    }
  }
}
