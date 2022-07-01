namespace OthelloLib;

internal class MinimaxComputerPlayer : IComputerPlayer
{
  public (int Row, int Column) GetNextPlacement(IOthelloGameState othelloGame)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<(int Row, int Column)> GetPlacementsUntilTurnChanges(IOthelloGameState othelloGame)
  {
    throw new NotImplementedException();
  }

  public void PlaceNext(IOthelloGame othelloGame)
  {
    throw new NotImplementedException();
  }

  public void PlaceUntilTurnChanges(IOthelloGame othelloGame)
  {
    throw new NotImplementedException();
  }
}