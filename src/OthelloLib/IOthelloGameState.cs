using OthelloLib.Enums;

namespace OthelloLib;

public interface IOthelloGameState
{
  public bool IsGameOver();

  public bool IsTie();

  public bool HasWinner();

  public Color Winner { get; }

  public Color Turn { get; }
  public int BlackScore { get; }
  public int WhiteScore { get; }

  public int GetPlayerScore(Color player);

  public int BoardSize { get; }

  public SquareState this[int row, int column] { get; }

  public SquareState[,] Board { get; }

  public bool IsValidPlacement(int row, int column);

  public bool HasValidPlacement();

  public IEnumerable<(int Row, int Column)> GetValidPlacements();

  public IOthelloGame CloneGame();
}