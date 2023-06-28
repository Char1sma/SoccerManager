using System;
using System.ComponentModel;

namespace SoccerManager.Client.Common
{
  public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
  {
    public event PropertyChangedEventHandler? PropertyChanged;
    public virtual void Dispose() { }

    protected void OnPropertyChanged(string? propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
