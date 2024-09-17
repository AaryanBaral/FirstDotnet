

using FirstCrudApp.Data;
using FirstCrudApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudApp.Repositories;

public class InDbGameRepository(GameStoreContext dbContext) : IGameRepository
{
    private readonly GameStoreContext _dbContext = dbContext;

    public async Task CreateGameAsync(Game game)
    {
        await _dbContext.Games.AddAsync(game);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(int id)
    {
        await _dbContext.Games.Where(game=> game.Id == id)
        .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        return await  _dbContext.Games.AsNoTracking().ToListAsync();
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await _dbContext.Games.FindAsync(id);
    }

    public async Task UpdateGameAsync(Game updatedGame)
    {
       _dbContext.Update(updatedGame);
        await _dbContext.SaveChangesAsync();
    }
}