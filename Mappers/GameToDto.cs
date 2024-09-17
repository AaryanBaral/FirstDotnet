using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCrudApp.Dtos;
using FirstCrudApp.Entities;

namespace FirstCrudApp.Mappers;
    public static class GameToDto
    {
        public static GameDto ToDto(this Game game){
            return new GameDto(
                game.Id,
                game.Name,
                game.Price,
                game.Genre,
                game.ReleaseDate,
                game.ImageUrl
            );
        }
    }
