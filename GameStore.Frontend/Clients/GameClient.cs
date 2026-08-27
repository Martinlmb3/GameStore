using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GameClient
{
    private readonly List<GameSummary> games =
    [
        new GameSummary()
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateOnly(1992, 7, 15)
        },
        new GameSummary()
        {
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateOnly(1992, 9, 30)
        },
        new GameSummary()
        {
            Id = 3,
            Name = "Fifa 26",
            Genre = "Sports",
            Price = 55.99M,
            ReleaseDate = new DateOnly(1992, 9, 27)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        if (string.IsNullOrWhiteSpace(game.GenreId))
        {
            throw new ArgumentException("GenreId cannot be null or whitespace.", nameof(game.GenreId));
        }

        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));
        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }
    public GameDetails getGame()
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentException.ThrowIfNull(game);
        var genre = genres.Single(Genre => string.Equals(
            genre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase));
        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
}

