using FluentValidation;
using Games.Minesweeper.API.Responses;

namespace Games.Minesweeper.API.Validators
{
  public class GameGetResponseValidator : AbstractValidator<GameGetResponse>
  {
    public GameGetResponseValidator()
    {
      RuleFor(x => x.ExternalId).NotNull().WithMessage(CommonValidatorConstants.GetNullMessage(nameof(GameGetResponse.ExternalId)));
    }
  }
}
