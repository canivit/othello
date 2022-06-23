namespace OthelloLib.Exceptions;

public class NoWinnerException : Exception
{
  internal NoWinnerException(string message) : base(message)
  {
  }
}