using MediatR;
using Games.Minesweeper.Domain.Models;

namespace Games.Minesweeper.Domain.Queries
{
  public class GetGameQuery : IRequest<Game>
  {
    public int Width { get; set; }
    public int Height { get; set; }
    public int NumberOfMines { get; set; }

    public GetGameQuery(int width, int height, int numberOfMines)
    {
      Width = width;
      Height = height;
      NumberOfMines = numberOfMines;
    }
  }
}
