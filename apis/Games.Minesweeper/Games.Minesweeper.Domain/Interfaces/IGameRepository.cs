using Games.Minesweeper.Domain.Models;

namespace Games.Minesweeper.Domain.Interfaces
{
  public interface IGameRepository
  {
    Task<Game> StartGame();
  }
}
