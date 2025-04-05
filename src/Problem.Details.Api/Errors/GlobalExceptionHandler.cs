using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Problem.Details.Api.Errors.Interfaces;

namespace Problem.Details.Api.Errors;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
  private readonly IHttpStatusCodeMapper _httpStatusCodeMapper;
  private readonly IProblemDetailsService _problemDetailsService;

  public GlobalExceptionHandler(
    IHttpStatusCodeMapper httpStatusCodeMapper,
    IProblemDetailsService problemDetailsService)
  {
    _httpStatusCodeMapper = httpStatusCodeMapper;
    _problemDetailsService = problemDetailsService;
  }

  /// <inheritdoc />
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    int httpStatusCode = _httpStatusCodeMapper.GetHttpStatusCodeByException(exception);

    var problemDetails = new ProblemDetails
    {
      Title = "An error occurred while processing your request.",
      Status = httpStatusCode,
      Type = exception.GetType().Name,
      Detail = exception.Message,
      Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
    };

    problemDetails.Extensions.TryAdd("requestId", httpContext.TraceIdentifier);

    return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
    {
      HttpContext = httpContext,
      Exception = exception,
      ProblemDetails = problemDetails
    });
  }
}
