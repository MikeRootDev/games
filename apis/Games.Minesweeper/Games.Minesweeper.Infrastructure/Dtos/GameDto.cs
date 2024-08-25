namespace Games.Minesweeper.Infrastructure.Dtos
{
  public class GameDto
  {
    public int GameId { get; set; }
    public Guid ExternalId { get; set; }
    public DateTimeOffset DateTimeStarted {  get; set; }
    public DateTimeOffset? DateTimeEnded { get; set; }
  }
}
