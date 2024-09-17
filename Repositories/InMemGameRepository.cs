using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCrudApp.Entities;

namespace FirstCrudApp.Repositories
{
    public class InMemGameRepository: IGameRepository
    {
        private static readonly List<Game> games = [
   new(){
        Id = 1,
        Name = "Street Fignter I",
        Price = 19.99M,
        Genre = "Fighting",
        ReleaseDate = new DateTime(2021,12,01),
        ImageUrl = "https://placehold.co/100"
    },
    new(){
        Id = 2,
        Name = "Street Fignter II",
        Price = 29.99M,
        Genre = "Fighting",
        ReleaseDate = new DateTime(2022,12,01),
        ImageUrl = "https://placehold.co/100"
    },
    new(){
        Id = 3,
        Name = "PUBG",
        Price = 199.99M,
        Genre = "Fighting",
        ReleaseDate = new DateTime(2016,08,04),
        ImageUrl = "https://placehold.co/100"
    },

];
        public void CreateGame(Game game)
        {
            game.Id = games.Max(t=>t.Id)+1;
            games.Add(game);
        }
        public void DeleteGame(int id) => games.RemoveAll(t => t.Id == id);
        public void UpdateGame(Game updatedGame)
        {
            var index = games.FindIndex(t => t.Id == updatedGame.Id);
            games[index] = updatedGame;
        }
        public Game? GetGameById(int id)
        {
            Game? game = games.Find(t => t.Id == id);
            return game;
        }
        public IEnumerable<Game> GetAllGames() => games;
    }
}