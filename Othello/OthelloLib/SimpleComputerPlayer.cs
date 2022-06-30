namespace OthelloLib;

internal class SimpleComputerPlayer : IComputerPlayer
{
  public (int row, int column) Play(IOthelloGameState othelloGame)
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
}