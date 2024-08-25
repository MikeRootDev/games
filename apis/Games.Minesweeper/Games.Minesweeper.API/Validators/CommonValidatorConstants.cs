namespace Games.Minesweeper.API.Validators
{
  public static class CommonValidatorConstants
  {
    public static string GetNullMessage(string nameOfProperty)
    {
      return $"{nameOfProperty} must not be null";
    }

    public static string GetInclusiveBetweenMessage(string nameOfProperty, int min, int max)
    {
      return $"{nameOfProperty} must be between {min} and {max}";
    }
  }
}
