using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Games.Minesweeper.API.Responses;
using Microsoft.AspNetCore.Mvc;
using Games.Minesweeper.API.Exceptions;

namespace Games.Minesweeper.API.Attributes
{
  public class GameGetResponseValidationAttribute : ActionFilterAttribute
  {
    private readonly ILogger<GameGetResponseValidationAttribute> _logger;
    private readonly IValidator<GameGetResponse> _validator;

    public GameGetResponseValidationAttribute(ILogger<GameGetResponseValidationAttribute> logger, IValidator<GameGetResponse> validator)
    {
      _logger = logger;
      _validator = validator;
    }

    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
      if (context.Result.GetType() == typeof(OkObjectResult))
      {
        var responseObject = (OkObjectResult)context.Result;

        var instance = responseObject.Value as GameGetResponse;

        if (instance != null)
        {
          var validationResult = await _validator.ValidateAsync(instance);

          if (!validationResult.IsValid)
          {
            _logger.LogCritical("Reponse object is invalid, breaks defined contract: {response}", responseObject.Value);
            throw new InvalidResponseValidationException("Response object invalid, breaks defined contract");
          }
        }
      }

      await next();
    }
  }
}
