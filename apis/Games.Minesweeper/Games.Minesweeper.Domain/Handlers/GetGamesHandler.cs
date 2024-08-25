using Games.Minesweeper.Domain.Queries;
using MediatR;
using Games.Minesweeper.Domain.Models;
using Games.Minesweeper.Domain.Interfaces;

namespace Games.Minesweeper.Domain.Handlers
{
  public class GetGamesHandler : IRequestHandler<GetGamesQuery, IEnumerable<Game>>
  {
    private IGameRepository _gameRepository;

    public GetGamesHandler(IGameRepository gameRepository)
    {
      _gameRepository = gameRepository;
    }

    public async Task<IEnumerable<Game>> Handle(GetGamesQuery query, CancellationToken cancellationToken)
    {
      return await _gameRepository.GetGames();
    }
  }
}
