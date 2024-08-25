using Dapper;
using Games.Minesweeper.Domain.Models;
using Games.Minesweeper.Domain.Interfaces;
using Games.Minesweeper.Infrastructure.Dtos;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Games.Minesweeper.Infrastructure
{
	public class GameRepository : IGameRepository
	{
    private readonly IDatabaseConnectionFactory _connectionFactory;
    private readonly ILogger<GameRepository> _logger;
    private readonly IMapper _mapper;

    public GameRepository(
      IDatabaseConnectionFactory connectionFactory,
      ILogger<GameRepository> logger,
      IMapper mapper)
    {
      _connectionFactory = connectionFactory;
      _logger = logger;
      _mapper = mapper;
    }

    public async Task<IEnumerable<Game>> GetGames()
    {
      try
      {
        using (var dbConn = _connectionFactory.GetMinesweeperConnection())
        {
          string sql = "SELECT * FROM dbo.Games";
          var dtos = await dbConn.QueryAsync<GameDto>(sql);
          var games = new List<Game>();
          return _mapper.Map<IEnumerable<Game>>(dtos);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Exception {ex}", ex);
        throw;
      }
    }
	}
}
