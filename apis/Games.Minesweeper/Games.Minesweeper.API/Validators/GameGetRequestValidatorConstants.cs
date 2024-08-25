namespace Games.Minesweeper.API.Validators
{
  public static class GameGetRequestValidatorConstants
  {
    public const int MinWidth = 0;
    public const int MaxWidth = 20;
    public const int MinHeight = 0;
    public const int MaxHeight = 20;
    public const int MinNumberOfMines = 5;
    public const int MaxNumberOfMines = 200;

    public const string WrongNumberOfMines = "Number of mines is too great for the given width and height";
  }
}
