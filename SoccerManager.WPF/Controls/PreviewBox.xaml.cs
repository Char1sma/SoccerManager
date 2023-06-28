using System.Windows;
using System.Windows.Controls;

namespace SoccerManager.Client.Controls
{
  /// <summary>
  /// Логика взаимодействия для PreviewBox.xaml
  /// </summary>
  public partial class PreviewBox
  {
    public static readonly DependencyProperty AbbreviationProperty = DependencyProperty.Register(
      "Abbreviation", typeof(string), typeof(PreviewBox));

    public string Abbreviation
    {
      get => (string)GetValue(AbbreviationProperty);
      set => SetValue(AbbreviationProperty, value);
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
      "Text", typeof(string), typeof(PreviewBox));

    public string Text
    {
      get => (string)GetValue(TextProperty);
      set => SetValue(TextProperty, value);
    }

    public PreviewBox()
    {
      InitializeComponent();
    }
  }
}
