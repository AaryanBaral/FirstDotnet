using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCrudApp.Entities;

namespace FirstCrudApp.Repositories;
    public interface IGameRepository
    {
        Task CreateGameAsync(Game game);
        Task DeleteGameAsync(int id);
        Task UpdateGameAsync(Game updatedGame);
        Task<Game?> GetGameByIdAsync(int id);
        Task<IEnumerable<Game>> GetAllGamesAsync(); 
    }