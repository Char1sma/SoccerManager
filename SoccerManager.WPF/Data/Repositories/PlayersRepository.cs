using Microsoft.EntityFrameworkCore;
using SoccerManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerManager.Client.Data.Repositories
{
  public interface IPlayersRepository
  {
    IEnumerable<Player> GetAll();
    Player Get(int id);
    bool Create(Player player);
    bool Exists(int id);
    bool Exists(Player player);
    bool Update(Player player, string name, string snils, DateTime birthDate, Club club);
    bool Delete(Player player);
    bool Save();
  }

  public class PlayersRepository : IPlayersRepository
  {
    #region Constructor

    public PlayersRepository(DataContext dataСontext)
    {
      _dataContext = dataСontext;
    }

    #endregion

    #region CRUD Methods

    public IEnumerable<Player> GetAll()
    {
      return _dataContext.Players.Include(p => p.Club).ToList();
    }

    public Player Get(int id)
    {
      return _dataContext.Players.Include(p => p.Club).FirstOrDefault();
    }

    public bool Create(Player player)
    {
      _dataContext.Add(player);

      return Save();
    }

    public bool Exists(int id)
    {
      return _dataContext.Players.Any(c => c.Id == id);
    }

    public bool Exists(Player player)
    {
      return _dataContext.Players.Contains(player);
    }

    public bool Update(Player player, string name, string snils, DateTime birthDate, Club club)
    {
      if (Exists(player))
      {
        player.Name = name;
        player.Snils = snils;
        player.BirthDate = birthDate;
        player.Club = club;
        return Save();
      }

      return false;
    }

    public bool Delete(Player player)
    {
      if (Exists(player))
      {
        _dataContext.Players.Remove(player);
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
