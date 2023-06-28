using System.Collections.Generic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace SoccerManager.Client.Common
{
  public abstract class ModalDialogViewModelBase : ViewModelBase, INotifyDataErrorInfo
  {
    public abstract object SetResult();

    #region INotifyDataErrorInfo

    private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

    public bool HasErrors => _propertyErrors.Any();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
      return _propertyErrors.GetValueOrDefault(propertyName, new List<string>());
    }

    public void AddError(string propertyName, string errorMessage)
    {
      if (!_propertyErrors.ContainsKey(propertyName))
      {
        _propertyErrors.Add(propertyName, new List<string>());
      }

      _propertyErrors[propertyName].Add(errorMessage);
      OnErrorsChanged(propertyName);
    }

    public void ClearErrors()
    {
      _propertyErrors.Clear();
      OnErrorsChanged();
    }

    public void ClearErrors(string propertyName)
    {
      if (_propertyErrors.Remove(propertyName))
      {
        OnErrorsChanged(propertyName);
      }
    }

    private void OnErrorsChanged(string? propertyName = null)
    {
      ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    #endregion
  }
}
