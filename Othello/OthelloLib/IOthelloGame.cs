namespace OthelloLib;

public interface IOthelloGame : IOthelloGameState
{
  public void PlaceDisk(int row, int column);
}