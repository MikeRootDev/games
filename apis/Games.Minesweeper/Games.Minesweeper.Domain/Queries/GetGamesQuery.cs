using MediatR;
using Games.Minesweeper.Domain.Models;

namespace Games.Minesweeper.Domain.Queries
{
  public class GetGamesQuery : IRequest<IEnumerable<Game>>
  {
    public GetGamesQuery() { }
  }
}
