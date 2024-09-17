

using FirstCrudApp.Data;
using FirstCrudApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudApp.Repositories;

public class InDbGameRepository(GameStoreContext dbContext) : IGameRepository
{
    private readonly GameStoreContext _dbContext = dbContext;

    public void CreateGame(Game game)
    {
        _dbContext.Games.Add(game);
        _dbContext.SaveChanges();
    }

    public void DeleteGame(int id)
    {
        _dbContext.Games.Where(game=> game.Id == id)
        .ExecuteDelete();
    }

    public IEnumerable<Game> GetAllGames()
    {
        return [.. _dbContext.Games.AsNoTracking()];
    }

    public Game? GetGameById(int id)
    {
        return _dbContext.Games.Find(id);
    }

    public void UpdateGame(Game updatedGame)
    {
        throw new NotImplementedException();
    }
}