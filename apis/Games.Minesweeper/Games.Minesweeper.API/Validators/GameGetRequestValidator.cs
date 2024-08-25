using FluentValidation;
using Games.Minesweeper.API.Requests;

namespace Games.Minesweeper.API.Validators
{
  public class GameGetRequestValidator : AbstractValidator<GameGetRequest>
  {
    public GameGetRequestValidator()
    {
      RuleFor(x => x.NumberOfMines).LessThan(x => Convert.ToInt32(x.Width * x.Height * .5));
    }
  }
}
