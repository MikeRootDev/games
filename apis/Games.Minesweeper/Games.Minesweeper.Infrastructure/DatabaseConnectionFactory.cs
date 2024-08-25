using Games.Minesweeper.Domain.Configuration;
using Games.Minesweeper.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Games.Minesweeper.Infrastructure
{
  public class DatabaseConnectionFactory : IDatabaseConnectionFactory
  {
    private readonly ConnectionStrings _connectionStrings;

    public DatabaseConnectionFactory(IOptions<ConnectionStrings> connectionStrings)
    {
      _connectionStrings = connectionStrings.Value;
    }

    public IDbConnection GetMinesweeperConnection()
    {
      return new SqlConnection(_connectionStrings.Minesweeper);
    }
  }
}
