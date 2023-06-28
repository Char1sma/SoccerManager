using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
using SoccerManager.Client.Data.Repositories;
using SoccerManager.Client.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SoccerManager.Client.Helpers;
using SoccerManager.Client.ViewModels.ModalContext;

namespace SoccerManager.Client.ViewModels
{
  public class FansManagementViewModel : ViewModelBase
  {
    #region Properties and fields

    #region Commands

    public ICommand AddFanCommand { get; set; }
    public ICommand DeleteFanCommand { get; set; }

    public ICommand EditFanCommand { get; set; }

    #endregion

    private readonly IFansRepository _fansRepository;
    private readonly IClubsRepository _clubsRepository;

    public ObservableCollection<Fan> Fans { get; set; }

    #endregion

    public FansManagementViewModel(IFansRepository fansRepository,
      IClubsRepository clubsRepository)
    {
      _fansRepository = fansRepository;
      _clubsRepository = clubsRepository;

      Fans = new ObservableCollection<Fan>(_fansRepository.GetAll());

      AddFanCommand = new RelayCommand(AddFan);
      DeleteFanCommand = new ParameterRelayCommand<Fan>(DeleteFan);
      EditFanCommand = new ParameterRelayCommand<Fan>(EditFan);
    }

    #region Methods

    private void EditFan(Fan fan)
    {
      var context = new FanEditingViewModel(fan, _clubsRepository.GetAll());
      var dialog = ModalWindowHelper.ShowDialog(context);

      if (dialog.Result != null)
      {
        _fansRepository.Save();
      }
    }

    private void DeleteFan(Fan fan)
    {
      _fansRepository.Delete(fan);
      Fans.Remove(fan);
    }

    private void AddFan()
    {
      var context = new FanAdditionViewModel();
      var dialog = ModalWindowHelper.ShowDialog(context);

      if (dialog.Result != null)
      {
        var fan = dialog.Result as Fan;
        Fans.Add(fan);
        _fansRepository.Create(fan);
      }
    }

    #endregion
  }
}
