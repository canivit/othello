namespace OthelloLib.Exceptions;

public class InvalidPlacementException : ArgumentException
{
  public InvalidPlacementException(string message) : base(message)
  {
  }
}