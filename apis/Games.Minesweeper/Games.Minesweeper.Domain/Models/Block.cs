namespace Games.Minesweeper.Domain.Models
{
  public class Block
  {
    public Position Position { get; set; }
    public bool IsMine { get; set; }

    public Block(int x, int y)
    {
      Position = new Position(x, y);
      IsMine = false;
    }
  }
}
