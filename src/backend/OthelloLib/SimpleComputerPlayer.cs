using OthelloLib.Enums;

namespace OthelloLib;

internal class SimpleComputerPlayer : IComputerPlayer
{
  public (int Row, int Column) GetNextPlacement(IOthelloGameState othelloGame)
  {
    if (othelloGame.IsGameOver())
    {
      throw new ArgumentException("Supplied game is over. There is no valid move.");
    }

    var placementsAndScores = othelloGame.GetValidPlacements().Select(placement =>
    {
      IOthelloGame copyGame = othelloGame.CloneGame();
      copyGame.PlaceDisk(placement.Row, placement.Column);
      int score = copyGame.GetPlayerScore(othelloGame.Turn);
      return new {placement.Row, placement.Column, Score = score};
    });

    var bestPlacement = placementsAndScores.OrderBy(placement => placement.Score).First();
    int row = bestPlacement.Row;
    int column = bestPlacement.Column;
    return (row, column);
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