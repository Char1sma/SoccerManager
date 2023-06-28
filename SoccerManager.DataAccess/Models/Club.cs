using System.Collections.Generic;

namespace SoccerManager.DataAccess.Models
{
  public class Club
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public ICollection<FanClub> FanClubs { get; set; }
  }
}
