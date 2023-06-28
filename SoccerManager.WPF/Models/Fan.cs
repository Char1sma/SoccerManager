using System.Collections.Generic;
using SoccerManager.Client.Common;

namespace SoccerManager.Client.Models
{
  public class Fan : ObservableObject
  {
    public int Id { get; set; }
    private string _name;

    public string Name
    {
      get => _name;
      set
      {
        _name = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(Abbreviation));
      }
    }
    public ICollection<FanClub> FanClubs { get; set; }

    public string Abbreviation => Name[0].ToString().ToUpper();
  }
}
