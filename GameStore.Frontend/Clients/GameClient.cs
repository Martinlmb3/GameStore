using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GameClient
{
    private readonly List<GameSummary> games =
    [
    new GameSummary (){
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateOnly(1992, 7, 15)
        },
    new GameSummary (){
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateOnly(1992, 9, 30)
        },
    new GameSummary (){
            Id = 3,
            Name = "Fifa 26",
            Genre = "Sports",
            Price = 55.99M,
            ReleaseDate = new DateOnly(1992, 9, 27)
        }
    ];
    public GameSummary[] GetGames() => [.. games];
}