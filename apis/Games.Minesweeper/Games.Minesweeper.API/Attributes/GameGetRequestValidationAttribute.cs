using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using Games.Minesweeper.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Games.Minesweeper.API.Attributes
{
  public class GameGetRequestValidationAttribute : ActionFilterAttribute
  {
    private readonly IValidator<GameGetRequest> _validator;

    public GameGetRequestValidationAttribute(IValidator<GameGetRequest> validator)
    {
      _validator = validator;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      var requestObject = context.ActionArguments.FirstOrDefault(x => x.Key != "cancellationToken");

      if (requestObject.Value is null)
      {
        return;
      }

      var instance = requestObject.Value as GameGetRequest;
      var validationResult = await _validator.ValidateAsync(instance!);

      if (!validationResult.IsValid)
      {
        var problemDetails = new ProblemDetails();
        problemDetails.Extensions.Add("traceid", System.Diagnostics.Activity.Current?.Id ?? context.HttpContext.TraceIdentifier);
        if (validationResult.Errors.Any()) {

          problemDetails.Detail = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
        }
        problemDetails.Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1";
        problemDetails.Title = "One or more validation errors occurred.";
        context.Result = new BadRequestObjectResult(problemDetails);
        return;
      }

      await next();
    }
  }
}
