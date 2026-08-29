using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static GameSummaryDto ToSummaryDto(this Game game) =>
        new(game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate);

    public static GameDetailsDto ToDetailsDto(this Game game) =>
        new(game.Id, game.Name, game.GenreId, game.Price, game.ReleaseDate);

    public static Game ToEntity(this CreateGameDto dto) =>
        new()
        {
            Name = dto.Name,
            GenreId = dto.GenreId,
            Price = dto.Price,
            ReleaseDate = dto.ReleaseDate
        };

    public static void ApplyTo(this UpdateGameDto dto, Game game)
    {
        game.Name = dto.Name;
        game.GenreId = dto.GenreId;
        game.Price = dto.Price;
        game.ReleaseDate = dto.ReleaseDate;
    }

    public static GenreDto ToDto(this Genre genre) => new(genre.Id, genre.Name);
}
