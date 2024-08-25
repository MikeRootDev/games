using Microsoft.AspNetCore.Mvc;

namespace Games.Minesweeper.API.Attributes
{
  public class ValidationFilterAttribute : TypeFilterAttribute
  {
    public ValidationFilterAttribute(Type type): base(type) { }
  }
}
