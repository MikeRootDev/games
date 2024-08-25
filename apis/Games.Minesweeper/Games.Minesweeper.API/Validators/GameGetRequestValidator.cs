using FluentValidation;
using Games.Minesweeper.API.Requests;

namespace Games.Minesweeper.API.Validators
{
  public class GameGetRequestValidator : AbstractValidator<GameGetRequest>
  {
    public GameGetRequestValidator()
    {
      #region Check for nulls
      RuleFor(x => x.Width)
        .NotNull()
        .WithMessage(CommonValidatorConstants.GetNullMessage(nameof(GameGetRequest.Width)));

      RuleFor(x => x.Height)
        .NotNull()
        .WithMessage(CommonValidatorConstants.GetNullMessage(nameof(GameGetRequest.Height)));

      RuleFor(x => x.NumberOfMines)
        .NotNull()
        .WithMessage(CommonValidatorConstants.GetNullMessage(nameof(GameGetRequest.NumberOfMines)));
      #endregion

      #region Check for correct ranges
      RuleFor(x => x.Width)
        .InclusiveBetween(GameGetRequestValidatorConstants.MinWidth, GameGetRequestValidatorConstants.MaxWidth)
        .When(x => x.Width.HasValue)
        .WithMessage(CommonValidatorConstants.GetInclusiveBetweenMessage(
          nameof(GameGetRequest.Width),
          GameGetRequestValidatorConstants.MinWidth,
          GameGetRequestValidatorConstants.MaxWidth));

      RuleFor(x => x.Height)
        .InclusiveBetween(GameGetRequestValidatorConstants.MinHeight, GameGetRequestValidatorConstants.MaxHeight)
        .When(x => x.Height.HasValue)
        .WithMessage(CommonValidatorConstants.GetInclusiveBetweenMessage(
          nameof(GameGetRequest.Height),
          GameGetRequestValidatorConstants.MinHeight,
          GameGetRequestValidatorConstants.MaxHeight));

      RuleFor(x => x.NumberOfMines)
        .ExclusiveBetween(GameGetRequestValidatorConstants.MinNumberOfMines, GameGetRequestValidatorConstants.MaxNumberOfMines)
        .When(x => x.NumberOfMines.HasValue)
        .WithMessage(CommonValidatorConstants.GetInclusiveBetweenMessage(
          nameof(GameGetRequest.NumberOfMines),
          GameGetRequestValidatorConstants.MinNumberOfMines,
          GameGetRequestValidatorConstants.MaxNumberOfMines));
      #endregion

      # region Check additional math
      RuleFor(x => x.NumberOfMines)
        .LessThan(x => Convert.ToInt32(x.Width!.Value * x.Height!.Value * .5))
        .When(x => x.Width.HasValue && x.Height.HasValue && x.NumberOfMines.HasValue
          && x.Width.Value >= GameGetRequestValidatorConstants.MinWidth && x.Width.Value <= GameGetRequestValidatorConstants.MaxWidth
          && x.Height.Value >= GameGetRequestValidatorConstants.MinHeight && x.Height.Value <= GameGetRequestValidatorConstants.MaxHeight
          && x.NumberOfMines.Value >= GameGetRequestValidatorConstants.MinNumberOfMines && x.NumberOfMines <= GameGetRequestValidatorConstants.MaxNumberOfMines)
        .WithMessage(GameGetRequestValidatorConstants.WrongNumberOfMines);
      #endregion
    }
  }
}
