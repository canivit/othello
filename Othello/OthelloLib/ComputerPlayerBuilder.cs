using OthelloLib.Enums;

namespace OthelloLib;

public static class ComputerPlayerBuilder
{
  public static IComputerPlayer BuildComputerPlayer(ComputerPlayerType type)
  {
    return type switch
    {
      ComputerPlayerType.Random => new RandomComputerPlayer(),
      ComputerPlayerType.Simple => new SimpleComputerPlayer(),
      ComputerPlayerType.Minimax => new MinimaxComputerPlayer(),
      _ => throw new ArgumentException("Invalid Computer Player Type")
    };
  }
}