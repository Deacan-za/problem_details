namespace Problem.Details.Api.Errors.Interfaces;

internal interface IHttpStatusCodeMapper
{
  int GetHttpStatusCodeByException(Exception exception);
}
