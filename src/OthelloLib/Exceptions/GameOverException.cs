namespace OthelloLib.Exceptions;

public class GameOverException : Exception
{
  internal GameOverException(string message) : base(message)
  {
  }
}