namespace OthelloLib.Exceptions;

public class GameNotOverException : Exception
{
  internal GameNotOverException(string message) : base(message)
  {
  }
}