using System.Collections.ObjectModel;
using System.Windows.Input;
using SoccerManager.Client.Common;
using SoccerManager.Client.Common.Command;
using SoccerManager.Client.Data.Repositories;
using SoccerManager.Client.Helpers;
using SoccerManager.Client.Models;
using SoccerManager.Client.ViewModels.ModalContext;

namespace SoccerManager.Client.ViewModels
{
  public class ClubsManagementViewModel : ViewModelBase
  {
    #region Properties and fields

    #region Commands

    public ICommand AddClubCommand {get; set; }

    public ICommand EditClubCommand { get; set; }

    public ICommand DeleteClubCommand { get; set; }

    #endregion

    private readonly IClubsRepository _clubsRepository;
    private readonly IPlayersRepository _playersRepository;

    public ObservableCollection<Club> Clubs { get; set; }
    
    #endregion
    

    #region Constructor

    public ClubsManagementViewModel(IClubsRepository clubsRepository, IPlayersRepository playersRepository)
    {
      _clubsRepository = clubsRepository;
      _playersRepository = playersRepository;

      Clubs = new ObservableCollection<Club>(_clubsRepository.GetAll());

      AddClubCommand = new RelayCommand(AddClub);
      EditClubCommand = new ParameterRelayCommand<Club>(EditClub);
      DeleteClubCommand = new ParameterRelayCommand<Club>(DeleteClub);
    }

    #endregion

    

    #region Methods
    public void EditClub(Club club)
    {
      var context = new ClubEditingViewModel(club, _playersRepository.GetAll());
      var dialog = ModalWindowHelper.ShowDialog(context);

      if (dialog.Result != null)
      {
        _clubsRepository.Save();
      }
    }

    public void DeleteClub(Club club)
    {
      _clubsRepository.Delete(club);
      Clubs.Remove(club);
    }

    public void AddClub()
    {
      var context = new ClubAdditionViewModel();
      var dialog = ModalWindowHelper.ShowDialog(context);

      if (dialog.Result != null)
      {
        var club = dialog.Result as Club;
        Clubs.Add(club);
        _clubsRepository.Create(club);
      }
    }

    #endregion
  }
}
