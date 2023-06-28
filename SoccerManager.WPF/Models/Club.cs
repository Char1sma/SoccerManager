using System.Collections.Generic;
using SoccerManager.Client.Common;

namespace SoccerManager.Client.Models
{
  public class Club : ObservableObject
  {
    public int Id { get; set; }

    private string _name;
    public string Name 
    { get => _name;
      set
      {
        _name = value;
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(Abbreviation));
        OnPropertyChanged(nameof(FullName));
      }
    }

    private string _city;
    public string City
    {
      get => _city;
      set
      {
        _city = value;
        OnPropertyChanged(nameof(City));
        OnPropertyChanged(nameof(Abbreviation));
        OnPropertyChanged(nameof(FullName));
      }
    }
    public ICollection<FanClub> FanClubs { get; set; }
    public ICollection<Player> Players { get; set; }

    public string Abbreviation => ($"{Name[0]}{City[0]}");
    public string FullName => ($"{Name}-{City}");
  }
}
