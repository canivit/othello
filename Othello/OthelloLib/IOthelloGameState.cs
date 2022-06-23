using OthelloLib.Enums;

namespace OthelloLib;

public interface IOthelloGameState
{
  public bool IsGameOver();

  public bool IsTie();

  public bool HasWinner();

  public Color Winner { get; }

  public Color Turn { get; }

  public int BoardSize { get; }

  public SquareState this[int row, int column] { get; }

  public bool IsValidPlacement(int row, int col);
}