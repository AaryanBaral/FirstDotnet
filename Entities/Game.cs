using System.ComponentModel.DataAnnotations;

namespace FirstCrudApp.Entities;

public class Game
{
    public int Id { get; set; }
    [Required][StringLength(50)] public required string Name { get; set; }
    [Required][Range(1, 1000)] public required decimal Price { get; set; }
    [Required] public required string Genre { get; set; }
    public required DateTime ReleaseDate { get; set; }
    [Url][StringLength(500)] public required string ImageUrl { get; set; }

}