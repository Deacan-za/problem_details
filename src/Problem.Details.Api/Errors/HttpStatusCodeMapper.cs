using Problem.Details.Api.Errors.Interfaces;
using Problem.Details.Api.Exceptions;

namespace Problem.Details.Api.Errors;

internal sealed class HttpStatusCodeMapper : IHttpStatusCodeMapper
{
  public int GetHttpStatusCodeByException(Exception exception)
  {
    return exception switch
    {
      TestException => StatusCodes.Status400BadRequest,
      NotImplementedException => StatusCodes.Status501NotImplemented,
      _ => StatusCodes.Status500InternalServerError
    };
  }
}
