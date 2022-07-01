using OthelloLib.Enums;

namespace OthelloLib;

public static class OthelloGameBuilder
{
  public static IOthelloGame BuildGame()
  {
    return new OthelloGame();
  }

  public static IOthelloGame BuildGame(SquareState[,] board, Color lastPlayed)
  {
    return new OthelloGame(board, lastPlayed);
  }
}