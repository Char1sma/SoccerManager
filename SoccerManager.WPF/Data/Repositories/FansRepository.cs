using Microsoft.EntityFrameworkCore;
using SoccerManager.Client.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoccerManager.Client.Data.Repositories
{
  public interface IFansRepository
  {
    IEnumerable<Fan> GetAll();
    Fan Get(int id);
    bool Create(Fan fan);
    bool Exists(int id);
    bool Exists(Fan fan);
    bool Update(Fan fan, string name);
    bool Delete(Fan fan);
    bool Save();
    bool AddFanClub(Fan fan, Club club);
    bool DeleteFanClub(FanClub fanClub);
  }

  public class FansRepository : IFansRepository
  {
    #region Constructor

    public FansRepository(DataContext dataСontext)
    {
      _dataContext = dataСontext;
    }

    #endregion

    #region CRUD Methods

    public IEnumerable<Fan> GetAll()
    {
      return _dataContext.Fans.Include(f => f.FanClubs).ToList();
    }

    public Fan Get(int id)
    {
      return _dataContext.Fans.Include(f => f.FanClubs).FirstOrDefault();
    }

    public bool Create(Fan fan)
    {
      _dataContext.Add(fan);

      return Save();
    }

    public bool Exists(int id)
    {
      return _dataContext.Fans.Any(f => f.Id == id);
    }

    public bool Exists(Fan fan)
    {
      return _dataContext.Fans.Contains(fan);
    }

    public bool Update(Fan fan, string name)
    {
      if (Exists(fan))
      {
        fan.Name = name;
        return Save();
      }

      return false;
    }

    public bool Delete(Fan fan)
    {
      if (Exists(fan))
      {
        _dataContext.Fans.Remove(fan);
        return Save();
      }

      return false;
    }

    public bool Save()
    {
      var saved = _dataContext.SaveChanges();
      return saved > 0;
    }

    #region Fan-Club methods

    public bool AddFanClub(Fan fan, Club club)
    {
      if (_dataContext.FanClubs.Any(fc => fc.Club == club && fc.Fan == fan))
        return false;

      _dataContext.Add(new FanClub()
      {
        FanId = fan.Id,
        Fan = fan,
        ClubId = club.Id,
        Club = club
      });

      return Save();
    }

    public bool DeleteFanClub(FanClub fanClub)
    {
      if (_dataContext.FanClubs.Contains(fanClub))
        return false;

      _dataContext.FanClubs.Remove(fanClub);

      return Save();
    }
    #endregion

    #endregion

    #region Properties and fields

    private readonly DataContext _dataContext;

    #endregion
  }
}
