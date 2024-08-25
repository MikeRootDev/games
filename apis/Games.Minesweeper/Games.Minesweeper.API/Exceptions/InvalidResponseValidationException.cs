namespace Games.Minesweeper.API.Exceptions
{
  public class InvalidResponseValidationException : Exception
  {
    public InvalidResponseValidationException(string message): base(message) { }
  }
}
