using Games.Minesweeper.Domain.Queries;
using MediatR;
using Games.Minesweeper.Domain.Models;
using Games.Minesweeper.Domain.Interfaces;

namespace Games.Minesweeper.Domain.Handlers
{
  public class GetGameHandler : IRequestHandler<GetGameQuery, Game>
  {
    private IGameRepository _gameRepository;

    public GetGameHandler(IGameRepository gameRepository)
    {
      _gameRepository = gameRepository;
    }

    public async Task<Game> Handle(GetGameQuery query, CancellationToken cancellationToken)
    {
      return await _gameRepository.StartGame();
    }
  }
}
