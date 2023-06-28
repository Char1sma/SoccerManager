using Microsoft.EntityFrameworkCore;
using SoccerManager.Client.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoccerManager.Client.Data.Repositories
{
  public interface IClubsRepository
  {
    IEnumerable<Club> GetAll();
    Club Get(int id);
    bool Create(Club club);
    bool Exists(int id);
    bool Exists(Club club);
    bool Update(Club club, string name, string city);
    bool Delete(Club club);
    bool Save();
  }

  public class ClubsRepository : IClubsRepository
  {
    #region Constructor

    public ClubsRepository(DataContext dataСontext)
    {
      _dataContext = dataСontext;
    }

    #endregion

    #region CRUD Methods

    public IEnumerable<Club> GetAll()
    {
      return _dataContext.Clubs.Include(c => c.FanClubs);
    }

    public Club Get(int id)
    {
      return _dataContext.Clubs.Include(c => c.FanClubs).FirstOrDefault();
    }

    public bool Create(Club club)
    {
      _dataContext.Add(club);

      return Save();
    }

    public bool Exists(int id)
    {
      return _dataContext.Clubs.Any(c => c.Id == id);
    }

    public bool Exists(Club club)
    {
      return _dataContext.Clubs.Contains(club);
    }

    public bool Update(Club club, string name, string city)
    {
      if (Exists(club))
      {
        club.Name = name;
        club.City = city;
        return Save();
      }

      return false;
    }

    public bool Delete(Club club)
    {
      if (Exists(club))
      {
        _dataContext.Clubs.Remove(club);
        return Save();
      }

      return false;
    }

    public bool Save()
    {
      var saved = _dataContext.SaveChanges();
      return saved > 0;
    }

    #endregion

    #region Properties and fields

    private readonly DataContext _dataContext;

    #endregion
  }
}
