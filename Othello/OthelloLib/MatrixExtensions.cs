namespace OthelloLib;

public static class MatrixExtensions
{
  public static IEnumerable<T> FlattenElements<T>(this T[,] matrix)
  {
    for (int row = 0; row < matrix.GetLength(0); row += 1)
    {
      for (int column = 0; column < matrix.GetLength(1); column += 1)
      {
        yield return matrix[row, column];
      }
    }
  }
  
  public static IEnumerable<(int Row, int Column)> FlattenPositions<T>(this T[,] matrix)
  {
    for (int row = 0; row < matrix.GetLength(0); row += 1)
    {
      for (int column = 0; column < matrix.GetLength(1); column += 1)
      {
        yield return (row, column);
      }
    }
  }
}