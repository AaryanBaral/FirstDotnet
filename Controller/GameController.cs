using FirstCrudApp.Dtos;
using FirstCrudApp.Entities;
using FirstCrudApp.Mappers;
using FirstCrudApp.Repositories;

namespace FirstCrudApp.Controller
{
    public static class GameController
    {
      
        public static RouteGroupBuilder GameRouteController(this IEndpointRouteBuilder routes)
        {
            // Mapping routes with common path
            var gamesRoute = routes.MapGroup("/games").WithParameterValidation();

            gamesRoute.MapGet("/", (IGameRepository repository) =>repository.GetAllGames().Select(game=> game.ToDto()));
            gamesRoute.MapGet("/{id}", (IGameRepository repository, int id) =>
            {
                Game? game = repository.GetGameById(id);
                if(game is null){
                    return Results.NotFound();
                }
                return Results.Ok(game.ToDto());

            }).WithName("GameIdRoute");

            gamesRoute.MapPost("/", (IGameRepository repository,CreateGameDto gameDto) =>
            {
                Game game = new(){
                    Name=gameDto.Name,
                    Price=gameDto.Price,
                    Genre=gameDto.Genre,
                    ReleaseDate=gameDto.ReleaseDate,
                    ImageUrl=gameDto.ImageUrl,
                };
                repository.CreateGame(game);
                return Results.CreatedAtRoute("GameIdRoute", new { id = game.Id }, game);
            });

            gamesRoute.MapDelete("/{id}", (int id,IGameRepository repository) =>
            {
                Game? game = repository.GetGameById(id);
                if (game is null) return Results.NotFound();
                repository.DeleteGame(id);
                return Results.Content("Deleted Sucessfully");

            });

            routes.MapPut("/games/{id}", (int id, UpdateGameDto updatedGameDto,IGameRepository repository) =>
            {
                Game? existingGame = repository.GetGameById(id);
                if (existingGame is null) return Results.NotFound();
                existingGame.Name = updatedGameDto.Name;
                existingGame.Price = updatedGameDto.Price;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUrl = updatedGameDto.ImageUrl;
                repository.UpdateGame(existingGame);
                return Results.Content("updated Sucessfully");
            });
            return gamesRoute;
        }

    }
}