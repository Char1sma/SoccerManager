using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SoccerManager.Client.Common;
using SoccerManager.Client.Models;

namespace SoccerManager.Client.ViewModels
{
  public class ClubsManagementViewModel : ViewModelBase
  {
    #region Constructor

    public ClubsManagementViewModel()
    {

    }

    #endregion

    #region Properties and fields

    public List<Club> Clubs { get; set; }

    public string Filter { get; set; }

    public List<Club> FilteredClubs => Clubs.Where(c => c.Name.Contains(Filter) || c.City.Contains(Filter)).Distinct().ToList();

    #endregion

    #region Methods

    

    #endregion
  }
}
