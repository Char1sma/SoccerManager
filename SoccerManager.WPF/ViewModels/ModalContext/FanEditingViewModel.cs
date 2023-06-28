using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
using SoccerManager.Client.Models;

namespace SoccerManager.Client.ViewModels.ModalContext
{
  public class FanEditingViewModel : ModalDialogViewModelBase
  {
    #region Properties and fields

    public Fan Fan { get; set; }

    private readonly IEnumerable<Club> _allClubs;

    public ObservableCollection<FanClub> FanClubs { get; set; }
    
    public ObservableCollection<Club> ClubsToAdd { get; set; }
    public Club SelectedClubToAdd { get; set; }

    public FanClub SelectedFanClub { get; set; }

    public ICommand AddFanClubCommand { get; set; }
    public ICommand DeleteFanClubCommand { get; set; }

    #endregion

    public FanEditingViewModel(Fan fan, IEnumerable<Club> allClubs)
    {
      Fan = fan;
      _allClubs = allClubs;

      FanClubs = new ObservableCollection<FanClub>(Fan.FanClubs);
      ClubsToAdd = new ObservableCollection<Club>(_allClubs.Where(c => !FanClubs.Select(fc => fc.Club).Contains(c)));

      AddFanClubCommand = new RelayCommand(AddFanClub);
      DeleteFanClubCommand = new RelayCommand(DeleteFanClub);
    }

    #region Methods

    public override object SetResult()
    {
      return Fan;
    }

    private void AddFanClub()
    {
      if (SelectedClubToAdd != null)
      {
        var fanClub = new FanClub()
        {
          Fan = Fan,
          Club = SelectedClubToAdd
        };

        Fan.FanClubs.Add(fanClub);
        FanClubs.Add(fanClub);
        ClubsToAdd.Remove(SelectedClubToAdd);
        SelectedClubToAdd = null;
        OnPropertyChanged(nameof(SelectedClubToAdd));
      }
    }

    private void DeleteFanClub()
    {
      if (SelectedFanClub != null)
      {
        Fan.FanClubs.Remove(SelectedFanClub);
        ClubsToAdd.Add(SelectedFanClub.Club);
        FanClubs.Remove(SelectedFanClub);
      }
    }

    #endregion
  }
}
