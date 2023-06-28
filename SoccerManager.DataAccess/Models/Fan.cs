using System.Collections.Generic;

namespace SoccerManager.DataAccess.Models
{
  public class Fan
  {
    public int Id { get; set; }
    public int Name { get; set; }
    public ICollection<FanClub> FanClubs { get; set; }
  }
}
