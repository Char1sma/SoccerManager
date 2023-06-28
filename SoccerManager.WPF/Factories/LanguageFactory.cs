using System.Globalization;

namespace SoccerManager.Client.Factories
{
  public class LanguageFactory
  {
    public CultureInfo GetLanguage(string languageName)
    {
      return new CultureInfo(languageName);
    }
  }
}
