using System.Linq;

namespace SoccerManager.Client.Helpers
{
  public static class ValidationHelper
  {
    public static bool DoesNotContainBannedSymbols(string value)
    {

      var bannedSymbols = @"{}/*()%&?[""]'";

      return value == null || bannedSymbols.Any(value.Contains);
    }
  }
}
