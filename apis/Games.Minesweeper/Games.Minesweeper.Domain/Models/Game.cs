namespace Games.Minesweeper.Domain.Models
{
  public class Game
  {
    public int GameId { get; set; }
    public Guid ExternalId { get; set; }
    public DateTimeOffset DateTimeStarted { get; set; }
    public DateTimeOffset? DateTimeEnded { get; set; }
  }
}
