using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using SoccerManager.Client.Factories;

namespace SoccerManager.Client.Services
{
  public class LanguageService
  {
    #region Constructor

    public LanguageService(LanguageFactory languageFactory)
    {
      _languageFactory = languageFactory;
      Languages.Clear();
      Languages.Add(new CultureInfo("en-US"));
      Languages.Add(new CultureInfo("ru-RU"));
    }

    #endregion

    #region Properties and fields

    private LanguageFactory _languageFactory;

    public event Action LanguageChanged;

    public List<CultureInfo> Languages { get; } = new List<CultureInfo>();

    public CultureInfo CurrentLanguage
    {
      get => System.Threading.Thread.CurrentThread.CurrentUICulture;
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof(value));

        System.Threading.Thread.CurrentThread.CurrentUICulture = value;
        SaveCurrentLanguage();

        ResourceDictionary dict = new ResourceDictionary();
        switch (value.Name)
        {
          case "ru-RU":
            dict.Source = new Uri($"/Resources/lang.{value.Name}.xaml", UriKind.Relative);
            break;
          default:
            dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
            break;
        }

        ResourceDictionary? oldDict = (Application.Current.Resources.MergedDictionaries.Where(d =>
          d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang."))).FirstOrDefault();

        if (oldDict != null)
        {
          int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
          Application.Current.Resources.MergedDictionaries.Remove(oldDict);
          Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
        }
        else
        {
          Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        LanguageChanged?.Invoke();
      }
    }

    #endregion

    #region Methods

    private void SaveCurrentLanguage()
    {
      Properties.Settings.Default.CurrentLanguage = CurrentLanguage.Name;
      Properties.Settings.Default.Save();
    }

    public void RefreshCurrentLanguage()
    {
      CurrentLanguage = _languageFactory.GetLanguage(Properties.Settings.Default.CurrentLanguage);
    }

    #endregion
  }
}
