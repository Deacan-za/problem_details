using Microsoft.AspNetCore.Mvc;
using Problem.Details.Api.Exceptions;

namespace Problem.Details.Api.Controllers;

[Route("exceptions")]
[ApiController]
public class ExceptionsController : ControllerBase
{
  [HttpGet("throw")]
  public IActionResult ThrowException()
  {
    throw new TestException("This is a test exception from controller.");
  }
}
