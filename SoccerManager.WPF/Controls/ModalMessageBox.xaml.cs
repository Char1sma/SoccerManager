using SoccerManager.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoccerManager.Client.Controls
{
  /// <summary>
  /// Логика взаимодействия для ModalMessageBox.xaml
  /// </summary>
  public partial class ModalMessageBox : Window
  {
    public static readonly DependencyProperty ContextProperty = DependencyProperty.Register(
      "Context", typeof(ViewModelBase), typeof(ModalMessageBox));

    public ViewModelBase Context
    {
      get => (ViewModelBase)GetValue(ContextProperty);
      set => SetValue(ContextProperty, value);
    }
    public ModalMessageBox()
    {
      InitializeComponent();
    }

    private void Cancel(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
