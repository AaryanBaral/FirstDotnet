using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCrudApp.Entities;

namespace FirstCrudApp.Repositories;
    public interface IGameRepository
    {
        void CreateGame(Game game);
        void DeleteGame(int id);
        void UpdateGame(Game updatedGame);
        Game? GetGameById(int id);
        IEnumerable<Game> GetAllGames(); 
    }