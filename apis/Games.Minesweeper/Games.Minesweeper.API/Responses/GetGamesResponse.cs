namespace Games.Minesweeper.API.Responses
{
  public class GetGamesResponse
  {
    public int GameId { get; set; }
    public Guid ExternalId { get; set; }
    public DateTimeOffset DateTimeStarted { get; set; }
    public DateTimeOffset? DateTimeEnded { get; set; }
  }
}
