namespace OthelloLib;

public interface IComputerPlayer
{
  public (int row, int column) Play(IOthelloGameState othelloGame);
}