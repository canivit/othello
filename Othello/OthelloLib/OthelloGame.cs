using OthelloLib.Enums;
using OthelloLib.Exceptions;

namespace OthelloLib;

internal class OthelloGame : IOthelloGame
{
  private static readonly int _boardSize = 8;

  private readonly SquareState[,] _board;
  private bool _gameOver;
  private Color _turn;

  internal OthelloGame()
  {
    _board = new SquareState[_boardSize, _boardSize];
    for (int row = 0; row < _boardSize; row += 1)
    {
      for (int col = 0; col < _boardSize; col += 1)
      {
        _board[row, col] = SquareState.Empty;
      }
    }

    _board[3, 3] = SquareState.White;
    _board[3, 4] = SquareState.Black;
    _board[4, 3] = SquareState.Black;
    _board[4, 4] = SquareState.White;

    _gameOver = false;
    _turn = Color.Black;
  }

  internal OthelloGame(SquareState[,] board, Color turn)
  {
    if (board.GetLength(0) != _boardSize || board.GetLength(1) != _boardSize)
    {
      throw new ArgumentException("Invalid board size.");
    }

    _board = new SquareState[_boardSize, _boardSize];
    Array.Copy(board, _board, board.Length);
    _gameOver = false;
    _turn = turn;
    if (HasValidPlacement())
    {
      return;
    }

    _turn = GetOppositeColor(_turn);
    if (HasValidPlacement())
    {
      return;
    }

    _gameOver = true;
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
      if (IsGameOver())
      {
        throw new GameOverException("The game is over.");
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

  public bool IsValidPlacement(int row, int column)
  {
    if (IsGameOver())
    {
      return false;
    }

    if (row < 0 || row > BoardSize - 1 || column < 0 || column > BoardSize - 1)
    {
      return false;
    }

    if (this[row, column] != SquareState.Empty)
    {
      return false;
    }

    IEnumerable<(int Row, int Column)> locations = FindCandidatePositions(row, column);
    return locations.Any(pair => OutflanksOpponent(row, column, pair.Row, pair.Column));
  }

  public bool HasValidPlacement()
  {
    return _board.FlattenPositions().Any(position => IsValidPlacement(position.Row, position.Column));
  }

  public IEnumerable<(int Row, int Column)> GetValidPlacements(int row, int column)
  {
    return _board.FlattenPositions().Where(position => IsValidPlacement(position.Row, position.Column));
  }

  public void PlaceDisk(int row, int column)
  {
    if (IsGameOver())
    {
      throw new GameOverException("The game is over.");
    }
    
    if (!IsValidPlacement(row, column))
    {
      throw new InvalidPlacementException("Invalid disk placement");
    }

    IEnumerable<(int Row, int Column)> locations = FindCandidatePositions(row, column)
      .Where(pair => OutflanksOpponent(row, column, pair.Row, pair.Column));
    foreach (var pair in locations)
    {
      PlaceDiskLinear(row, column, pair.Row, pair.Column, _turn);
    }

    _turn = GetOppositeColor(_turn);
    if (HasValidPlacement())
    {
      return;
    }

    _turn = GetOppositeColor(_turn);
    if (HasValidPlacement())
    {
      return;
    }

    _gameOver = true;
  }

  private int CountSquareState(SquareState state)
  {
    return _board.FlattenElements().Count(cell => cell == state);
  }

  private IEnumerable<(int Row, int Column)> FindCandidatePositions(int row, int column)
  {
    int r;
    int c;
    IList<(int Row, int Column)> locations = new List<(int Row, int Column)>();

    for (r = row - 2; r >= 0; r -= 1)
    {
      if (BoardHasColor(r, column, _turn))
      {
        locations.Add((r, column));
        break;
      }
    }

    for (c = column - 2; c >= 0; c -= 1)
    {
      if (BoardHasColor(row, c, _turn))
      {
        locations.Add((row, c));
        break;
      }
    }

    for (r = row + 2; r <= BoardSize - 1; r += 1)
    {
      if (BoardHasColor(r, column, _turn))
      {
        locations.Add((r, column));
        break;
      }
    }

    for (c = column + 2; c <= BoardSize - 1; c++)
    {
      if (BoardHasColor(row, c, _turn))
      {
        locations.Add((row, c));
        break;
      }
    }

    r = row - 2;
    c = column - 2;
    while (r >= 0 && c >= 0)
    {
      if (BoardHasColor(r, c, _turn))
      {
        locations.Add((r, c));
        break;
      }

      r -= 1;
      c -= 1;
    }

    r = row + 2;
    c = column - 2;
    while (r <= BoardSize - 1 && c >= 0)
    {
      if (BoardHasColor(r, c, _turn))
      {
        locations.Add((r, c));
        break;
      }

      r += 1;
      c -= 1;
    }

    r = row + 2;
    c = column + 2;
    while (r <= BoardSize - 1 && c <= BoardSize - 1)
    {
      if (BoardHasColor(r, c, _turn))
      {
        locations.Add((r, c));
        break;
      }

      r += 1;
      c += 1;
    }

    r = row - 2;
    c = column + 2;
    while (r >= 0 && c <= BoardSize - 1)
    {
      if (BoardHasColor(r, c, _turn))
      {
        locations.Add((r, c));
        break;
      }

      r -= 1;
      c += 1;
    }

    return locations;
  }

  private bool BoardHasColor(int row, int column, Color color)
  {
    return color == Color.Black ? _board[row, column] == SquareState.Black : _board[row, column] == SquareState.White;
  }

  private bool OutflanksOpponent(int fromRow, int fromColumn, int toRow, int toColumn)
  {
    Color opponent = GetOppositeColor(_turn);
    int rowDelta = Math.Min(Math.Max(toRow - fromRow, -1), 1);
    int columnDelta = Math.Min(Math.Max(toColumn - fromColumn, -1), 1);

    int row = fromRow + rowDelta;
    int column = fromColumn + columnDelta;
    int steps = Math.Max(Math.Abs(toRow - row), Math.Abs(toColumn - column));
    for (int i = 0; i < steps; i += 1)
    {
      if (!BoardHasColor(row, column, opponent))
      {
        return false;
      }

      row += rowDelta;
      column += columnDelta;
    }

    return true;
  }

  private void PlaceDiskLinear(int fromRow, int fromColumn, int toRow, int toColumn, Color color)
  {
    int rowDelta = Math.Min(Math.Max(toRow - fromRow, -1), 1);
    int columnDelta = Math.Min(Math.Max(toColumn - fromColumn, -1), 1);

    int row = fromRow;
    int column = fromColumn;
    int steps = Math.Max(Math.Abs(toRow - row), Math.Abs(toColumn - column));
    for (int i = 0; i < steps; i += 1)
    {
      _board[row, column] = GetSquareStateFromColor(color);
      row += rowDelta;
      column += columnDelta;
    }
  }

  private static Color GetOppositeColor(Color color)
  {
    return color == Color.Black ? Color.White : Color.Black;
  }

  private static SquareState GetSquareStateFromColor(Color color)
  {
    return color == Color.Black ? SquareState.Black : SquareState.White;
  }
}