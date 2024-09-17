using FirstCrudApp.Dtos;
using FirstCrudApp.Entities;
using FirstCrudApp.Mappers;
using FirstCrudApp.Repositories;

namespace FirstCrudApp.EndPoints
{
    public static class GameController
    {
      
        public static RouteGroupBuilder GameRouteController(this IEndpointRouteBuilder routes)
        {
            // Mapping routes with common path
            var gamesRoute = routes.MapGroup("/games").WithParameterValidation();

            gamesRoute.MapGet("/", async (IGameRepository repository) =>(await repository.GetAllGamesAsync()).Select(game=> game.ToDto()));
            gamesRoute.MapGet("/{id}", async(IGameRepository repository, int id) =>
            {
                Game? game = await repository.GetGameByIdAsync(id);
                if(game is null){
                    return Results.NotFound();
                }
                return Results.Ok(game.ToDto());

            }).WithName("GameIdRoute");

            gamesRoute.MapPost("/", async (IGameRepository repository,CreateGameDto gameDto) =>
            {
                Game game = new(){
                    Name=gameDto.Name,
                    Price=gameDto.Price,
                    Genre=gameDto.Genre,
                    ReleaseDate=gameDto.ReleaseDate,
                    ImageUrl=gameDto.ImageUrl,
                };
                await repository.CreateGameAsync(game);
                return Results.CreatedAtRoute("GameIdRoute", new { id = game.Id }, game);
            });

            gamesRoute.MapDelete("/{id}", async(int id,IGameRepository repository) =>
            {
                Game? game = await repository.GetGameByIdAsync(id);
                if (game is null) return Results.NotFound();
                await repository.DeleteGameAsync(id);
                return Results.Content("Deleted Sucessfully");

            });

            routes.MapPut("/games/{id}", async(int id, UpdateGameDto updatedGameDto,IGameRepository repository) =>
            {
                Game? existingGame = await repository.GetGameByIdAsync(id);
                if (existingGame is null) return Results.NotFound();
                existingGame.Name = updatedGameDto.Name;
                existingGame.Price = updatedGameDto.Price;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUrl = updatedGameDto.ImageUrl;
                await repository.UpdateGameAsync(existingGame);
                return Results.Content("updated Sucessfully");
            });
            return gamesRoute;
        }

    }
}