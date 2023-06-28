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
using SoccerManager.Client.Common;

namespace SoccerManager.Client.Controls
{
  /// <summary>
  /// Логика взаимодействия для ModalWindow.xaml
  /// </summary>
  public partial class ModalWindow : Window
  {
    public static readonly DependencyProperty ContextProperty = DependencyProperty.Register(
      "Context", typeof(ModalDialogViewModelBase), typeof(ModalWindow));

    public ModalDialogViewModelBase Context
    {
      get => (ModalDialogViewModelBase)GetValue(ContextProperty);
      set => SetValue(ContextProperty, value);
    }

    public ModalWindow()
    {
      InitializeComponent();
    }

    public object Result { get; set; }

    private void Submit(object sender, RoutedEventArgs e)
    {
      var result = Context.SetResult();
      if (result != null)
      {
        Result = result;
        Close();
      }
    }
    private void Cancel(object sender, RoutedEventArgs e)
    {
      Result = null;
      Close();
    }
  }
}
