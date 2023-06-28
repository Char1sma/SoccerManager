using System.Linq;
using System.Windows;

namespace SoccerManager.Client.Helpers
{
  public static class ResourceHelper
  {
    public static string GetResource(string resourceName)
    {
      ResourceDictionary dict = (Application.Current.Resources.MergedDictionaries.Where(d =>
        d.Source != null && d.Source.OriginalString.StartsWith("/Resources/lang."))).FirstOrDefault();

      return (string)dict[resourceName];
    }
  }
}
