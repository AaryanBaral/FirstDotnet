

using System.ComponentModel.DataAnnotations;

namespace FirstCrudApp.Dtos;
public record GameDto
(
    int Id,
    string Name,
    decimal Price,
    string Genre,
    DateTime ReleaseDate,
    string ImageUrl

);
public record CreateGameDto
(
    int Id,
    [Required][StringLength(50)]string Name,
    [Required][Range(1, 1000)]decimal Price,
    [Required] string Genre,
    [Required]DateTime ReleaseDate,
    [Url][StringLength(500)]string ImageUrl

);
public record UpdateGameDto
(
    int Id,
    [Required][StringLength(50)]string Name,
    [Required][Range(1, 1000)]decimal Price,
    [Required] string Genre,
    [Required]DateTime ReleaseDate,
    [Url][StringLength(500)]string ImageUrl
);
