using System;
using System.Globalization;
using System.Windows.Data;

namespace SoccerManager.Client.Converters
{
  public class LanguageToNameConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var selectedCulture = (CultureInfo)value;
      return selectedCulture.EnglishName;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return new CultureInfo((string)value);
    }
  }
}
