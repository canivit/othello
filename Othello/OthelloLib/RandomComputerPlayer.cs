namespace OthelloLib;

internal class RandomComputerPlayer : IComputerPlayer
{
  private readonly Random _random;

  internal RandomComputerPlayer()
  {
    _random = new Random();
  }

  public (int row, int column) Play(IOthelloGameState othelloGame)
  {
    if (othelloGame.IsGameOver())
    {
      throw new ArgumentException("Supplied game is over. There is no valid move.");
    }

    List<(int Row, int Column)> validPlacements = othelloGame.GetValidPlacements().ToList();
    int index = _random.Next(validPlacements.Count);
    return validPlacements[index];
  }
}