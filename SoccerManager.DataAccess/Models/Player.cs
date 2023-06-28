using System;

namespace SoccerManager.DataAccess.Models
{
  public class Player
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Snils { get; set; }
    public Club Club { get; set; }
  }
}
