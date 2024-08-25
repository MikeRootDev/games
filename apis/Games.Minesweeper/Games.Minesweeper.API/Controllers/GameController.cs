using System.Net;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Games.Minesweeper.Domain.Models;
using Games.Minesweeper.Domain.Queries;
using Games.Minesweeper.API.Responses;
using Games.Minesweeper.API.Requests;
using Games.Minesweeper.API.Attributes;

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
    [ProducesResponseType(typeof(GetGameResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ValidationFilter(typeof(GameGetRequestValidationAttribute))]
    public async Task<ActionResult<IEnumerable<GetGameResponse>>> GetNewGame([FromQuery]GameGetRequest request, CancellationToken cancellationToken)
    {
      try
      {
        var command = new GetGameQuery(request.Width, request.Height, request.NumberOfMines);
        var games = await _mediator.Send(command, cancellationToken);
        return Ok(_mapper.Map<GetGameResponse>(games));
      }
      catch (Exception ex)
      {
        _logger.LogError("{methodName} threw exception {ex}", nameof(GetNewGame), ex);
        throw;
      }
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
