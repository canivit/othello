using OthelloLib.Enums;

namespace OthelloLib;

internal class RandomComputerPlayer : IComputerPlayer
{
  private readonly Random _random;

  internal RandomComputerPlayer()
  {
    _random = new Random();
  }

  public (int Row, int Column) GetNextPlacement(IOthelloGameState othelloGame)
  {
    if (othelloGame.IsGameOver())
    {
      throw new ArgumentException("Supplied game is over. There is no valid move.");
    }

    List<(int Row, int Column)> validPlacements = othelloGame.GetValidPlacements().ToList();
    int index = _random.Next(validPlacements.Count);
    return validPlacements[index];
  }

  public IEnumerable<(int Row, int Column)> GetPlacementsUntilTurnChanges(IOthelloGameState othelloGame)
  {
    if (othelloGame.IsGameOver())
    {
      throw new ArgumentException("Supplied game is over. There is no valid move.");
    }

    IOthelloGame copyGame = othelloGame.CloneGame();
    Color turn = copyGame.Turn;
    var placements = new List<(int Row, int Column)>();
    while (!copyGame.IsGameOver() && copyGame.Turn == turn)
    {
      (int Row, int Column) placement = GetNextPlacement(copyGame);
      copyGame.PlaceDisk(placement.Row, placement.Column);
      placements.Add(placement);
    }

    return placements;
  }

  public void PlaceNext(IOthelloGame othelloGame)
  {
    (int Row, int Column) nextPlacement = GetNextPlacement(othelloGame);
    othelloGame.PlaceDisk(nextPlacement.Row, nextPlacement.Column);
  }

  public void PlaceUntilTurnChanges(IOthelloGame othelloGame)
  {
    IEnumerable<(int Row, int Column)> placements = GetPlacementsUntilTurnChanges(othelloGame);
    foreach (var placement in placements)
    {
      othelloGame.PlaceDisk(placement.Row, placement.Column);
    }
  }
}