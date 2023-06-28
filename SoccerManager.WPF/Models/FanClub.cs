namespace SoccerManager.Client.Models
{
  public class FanClub
  {
    public int FanId { get; set; }
    public int ClubId { get; set; }
    public Fan Fan { get; set; }
    public Club Club { get; set; }
  }
}
