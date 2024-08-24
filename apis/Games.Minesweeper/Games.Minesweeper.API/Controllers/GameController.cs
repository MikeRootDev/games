using Microsoft.AspNetCore.Mvc;
using Games.Minesweeper.Domain.Models;

namespace Games.Minesweeper.API.Controllers
{
  /// <summary>
  /// Game Controller
  /// </summary>
  [ApiController]
  [Route("v1/[controller]")]
  public class GameController : Controller
  {
    /// <summary>
    /// Get starts a new game
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Block>>> GetNewGame()
    {
      return Ok(new List<Block>());
    }

    /// <summary>
    /// Put checks a user's click to see if they've selected a mine
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> CheckClickedBlock()
    {
      return Ok(new List<Block>());
    }

    /// <summary>
    /// Post saves the current game
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SaveGame()
    {
      return Ok(new List<Block>());
    }
  }
}
