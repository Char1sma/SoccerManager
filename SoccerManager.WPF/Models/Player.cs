using System;
using SoccerManager.Client.Common;

namespace SoccerManager.Client.Models
{
  public class Player : ObservableObject
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
        OnPropertyChanged(nameof(PlayerInfo));
      }
    }

    
    public string Snils { get; set; }

    private DateTime _birthDate;

    public DateTime BirthDate
    {
      get => _birthDate;
      set
      {
        _birthDate = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(PlayerInfo));
      }
    }

    private Club _club;

    public Club? Club
    {
      get => _club;
      set
      {
        _club = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(PlayerInfo));
        OnPropertyChanged(nameof(ClubName));
      }
    }

    public string Abbreviation => Name[0].ToString().ToUpper();
    public string ClubName => Club != null ? Club.FullName : "-";
    public string PlayerInfo => $"{Name}\n{BirthDate.ToShortDateString()}\n{ClubName}";
  }
}
