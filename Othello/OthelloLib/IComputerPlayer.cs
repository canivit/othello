namespace OthelloLib;

public interface IComputerPlayer
{
  public (int Row, int Column) GetNextPlacement(IOthelloGameState othelloGame);
  public IEnumerable<(int Row, int Column)> GetPlacementsUntilTurnChanges(IOthelloGameState othelloGame);
  public void PlaceNext(IOthelloGame othelloGame);
  public void PlaceUntilTurnChanges(IOthelloGame othelloGame);
}