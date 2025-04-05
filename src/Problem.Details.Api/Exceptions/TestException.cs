namespace Problem.Details.Api.Exceptions;

public sealed class TestException : Exception
{
  public TestException(string message) : base(message)
  { }

  public TestException(string message, Exception innerException) : base(message, innerException)
  { }
}
