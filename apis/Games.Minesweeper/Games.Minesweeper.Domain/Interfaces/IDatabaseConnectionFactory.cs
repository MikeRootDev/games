using System.Data;

namespace Games.Minesweeper.Domain.Interfaces
{
  public interface IDatabaseConnectionFactory
  {
    IDbConnection GetMinesweeperConnection();
  }
}
