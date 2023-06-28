using System;

namespace SoccerManager.Client.Common
{
  public abstract class ViewModelBase : ObservableObject, IDisposable
  {
    public virtual void Dispose() { }
  }
}
