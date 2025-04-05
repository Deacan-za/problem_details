using Problem.Details.Api.Errors;
using Problem.Details.Api.Errors.Interfaces;

namespace Problem.Details.Api.Extensions;

internal static class ErrorServiceRegister
{
  internal static IServiceCollection AddErrorServices(this IServiceCollection services)
  {
    services.AddProblemDetails();
    services.AddExceptionHandler<GlobalExceptionHandler>();
    services.AddSingleton<IHttpStatusCodeMapper, HttpStatusCodeMapper>();
    return services;
  }
}
