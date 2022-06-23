using OthelloLib.Enums;
using OthelloLib.Exceptions;

namespace OthelloLib;

public class OthelloGame : IOthelloGame
{
  private static readonly int _boardSize = 8;

  private readonly SquareState[,] _board;
  private bool _gameOver;
  private Color _turn;

  internal OthelloGame()
  {
    _board = new SquareState[_boardSize, _boardSize];
    for (int r = 0; r < _boardSize; r += 1)
    {
      for (int c = 0; c < _boardSize; c += 1)
      {
        _board[r, c] = SquareState.Empty;
      }
    }

    _board[3, 3] = SquareState.White;
    _board[3, 4] = SquareState.Black;
    _board[4, 3] = SquareState.Black;
    _board[4, 4] = SquareState.White;

    _gameOver = false;
    _turn = Color.Black;
  }

  public bool IsGameOver()
  {
    return _gameOver;
  }

  public bool IsTie()
  {
    return IsGameOver() && CountSquareState(SquareState.Black) == CountSquareState(SquareState.White);
  }

  public bool HasWinner()
  {
    return IsGameOver() && !IsTie();
  }

  public Color Winner
  {
    get
    {
      if (!IsGameOver())
      {
        throw new GameNotOverException("Game is not over. There is no winner.");
      }

      int blackCount = CountSquareState(SquareState.Black);
      int whiteCount = CountSquareState(SquareState.White);
      if (blackCount == whiteCount)
      {
        throw new NoWinnerException("Game is tie. No winner.");
      }

      return blackCount > whiteCount ? Color.Black : Color.White;
    }
  }

  public Color Turn
  {
    get
    {
      if (!IsGameOver())
      {
        throw new GameOverException("Game is over.");
      }

      return _turn;
    }
  }

  public int BoardSize => _board.GetLength(0);

  public SquareState this[int row, int column]
  {
    get
    {
      if (row < 0 || row > BoardSize - 1)
      {
        string message =
          $"Invalid row index. Row index must be in between 0 and {BoardSize - 1} inclusive. It was {row}.";
        throw new ArgumentException(message);
      }

      if (column < 0 || column > BoardSize - 1)
      {
        string message =
          $"Invalid column index. Column index must be in between 0 and {BoardSize - 1} inclusive. It was {column}";
        throw new ArgumentException(message);
      }

      return _board[row, column];
    }
  }

  public bool IsValidPlacement(int row, int col)
  {
    throw new NotImplementedException();
  }

  public void PlaceDisk(int row, int column)
  {
    throw new NotImplementedException();
  }

  private int CountSquareState(SquareState state)
  {
    int count = 0;
    for (int r = 0; r < BoardSize; r += 1)
    {
      for (int c = 0; c < BoardSize; c += 1)
      {
        if (_board[r, c] == state)
        {
          count += 1;
        }
      }
    }

    return count;
  }
}