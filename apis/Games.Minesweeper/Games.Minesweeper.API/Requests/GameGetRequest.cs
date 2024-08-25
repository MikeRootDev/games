namespace Games.Minesweeper.API.Requests
{
  public class GameGetRequest
  {
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int? NumberOfMines { get; set; }
  }
}
