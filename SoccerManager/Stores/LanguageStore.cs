using System;

namespace SoccerManager.Client.Stores
{
  public class LanguageStore
  {
    private string _language;

    public string Language
    {
      get => _language;
      set
      {
        _language = value;
        OnLanguageChanged();
      }
    }

    public event Action LanguageChanged;

    private void OnLanguageChanged()
    {
      LanguageChanged?.Invoke();
    }
  }
}
