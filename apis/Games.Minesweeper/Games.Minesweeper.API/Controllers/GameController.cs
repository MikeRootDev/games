using Microsoft.AspNetCore.Mvc;
using Games.Minesweeper.Domain.Models;
using MediatR;
using Games.Minesweeper.Domain.Queries;
using AutoMapper;
using Games.Minesweeper.API.Responses;

namespace Games.Minesweeper.API.Controllers
{
  /// <summary>
  /// Game Controller
  /// </summary>
  [ApiController]
  [Route("v1/[controller]")]
  public class GameController : Controller
  {
    private readonly ILogger<GameController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GameController(
      ILogger<GameController> logger,
      IMediator mediator,
      IMapper mapper)
    {
      _logger = logger;
      _mediator = mediator;
      _mapper = mapper;
    }

    /// <summary>
    /// Get starts a new game
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetGamesResponse>>> GetNewGame(CancellationToken cancellationToken)
    {
      var command = new GetGamesQuery();
      var games = await _mediator.Send(command, cancellationToken);
      return Ok(_mapper.Map<IEnumerable<GetGamesResponse>>(games));
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
