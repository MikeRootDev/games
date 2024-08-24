using Microsoft.AspNetCore.Mvc;
using Games.Minesweeper.Domain.Models;
using Games.Minesweeper.Domain.Requests;

namespace Games.Minesweeper.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GameController : ControllerBase
  {
    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Block> GetNewGame()
    {
      return new List<Block>();
    }

    [HttpPut]
    public IEnumerable<Block> CheckClickedBlock([FromBody] GamePutRequest request)
    {
      return new List<Block>();
    }

    [HttpPost]
    public IEnumerable<Block> SaveGame()
    {
      return new List<Block>();
    }
  }
}
