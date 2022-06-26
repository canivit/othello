using OthelloLib;
using OthelloLib.Enums;

namespace OthelloLibTest;

[TestClass]
public class OthelloGameTests
{
  [TestMethod]
  // Test that PlaceDisk outflanks the opponent disks correctly
  public void TestPlaceDiskOutflankOpponent()
  {
    IOthelloGame board = OthelloGameBuilder.BuildGame();

    // North => South
    Assert.AreEqual(Color.Black, board.Turn);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(SquareState.Empty, board[2, 3]);
    board.PlaceDisk(2, 3);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(Color.White, board.Turn);

    // West => East
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(SquareState.Empty, board[4, 2]);
    board.PlaceDisk(4, 2);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.White, board[4, 3]);
    Assert.AreEqual(SquareState.White, board[4, 2]);
    Assert.AreEqual(Color.Black, board.Turn);

    // NorthEast
    Assert.AreEqual(SquareState.Black, board[3, 4]);
    Assert.AreEqual(SquareState.White, board[4, 3]);
    Assert.AreEqual(SquareState.Empty, board[5, 2]);
    board.PlaceDisk(5, 2);
    Assert.AreEqual(SquareState.Black, board[3, 4]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(SquareState.Black, board[5, 2]);
    Assert.AreEqual(Color.White, board.Turn);

    //SouthEast
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.Empty, board[2, 2]);
    board.PlaceDisk(2, 2);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(Color.Black, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[3, 2]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[3, 4]);
    Assert.AreEqual(SquareState.White, board[4, 2]);
    Assert.AreEqual(SquareState.Black, board[5, 2]);
    board.PlaceDisk(3, 2);
    Assert.AreEqual(SquareState.Black, board[3, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 2]);
    Assert.AreEqual(SquareState.Black, board[5, 2]);
    Assert.AreEqual(Color.White, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[6, 2]);
    Assert.AreEqual(SquareState.Black, board[5, 2]);
    Assert.AreEqual(SquareState.Black, board[4, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 2]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    board.PlaceDisk(6, 2);
    Assert.AreEqual(SquareState.White, board[6, 2]);
    Assert.AreEqual(SquareState.White, board[5, 2]);
    Assert.AreEqual(SquareState.White, board[4, 2]);
    Assert.AreEqual(SquareState.White, board[3, 2]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(Color.Black, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[5, 5]);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    board.PlaceDisk(5, 5);
    Assert.AreEqual(SquareState.Black, board[5, 5]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(Color.White, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[2, 5]);
    Assert.AreEqual(SquareState.Black, board[3, 4]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(SquareState.White, board[5, 2]);
    board.PlaceDisk(2, 5);
    Assert.AreEqual(SquareState.White, board[2, 5]);
    Assert.AreEqual(SquareState.White, board[3, 4]);
    Assert.AreEqual(SquareState.White, board[4, 3]);
    Assert.AreEqual(SquareState.White, board[5, 2]);
    Assert.AreEqual(Color.Black, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[4, 1]);
    Assert.AreEqual(SquareState.White, board[3, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[4, 2]);
    Assert.AreEqual(SquareState.White, board[4, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    board.PlaceDisk(4, 1);
    Assert.AreEqual(SquareState.Black, board[4, 1]);
    Assert.AreEqual(SquareState.Black, board[3, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 2]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    Assert.AreEqual(Color.White, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[6, 6]);
    Assert.AreEqual(SquareState.Black, board[5, 5]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    board.PlaceDisk(6, 6);
    Assert.AreEqual(SquareState.White, board[6, 6]);
    Assert.AreEqual(SquareState.White, board[5, 5]);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(Color.Black, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[4, 5]);
    Assert.AreEqual(SquareState.White, board[3, 4]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    board.PlaceDisk(4, 5);
    Assert.AreEqual(SquareState.Black, board[4, 5]);
    Assert.AreEqual(SquareState.Black, board[3, 4]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(Color.White, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[3, 1]);
    Assert.AreEqual(SquareState.Black, board[3, 2]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    board.PlaceDisk(3, 1);
    Assert.AreEqual(SquareState.White, board[3, 1]);
    Assert.AreEqual(SquareState.White, board[3, 2]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(Color.Black, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[2, 1]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[3, 1]);
    Assert.AreEqual(SquareState.Black, board[4, 1]);
    Assert.AreEqual(SquareState.White, board[3, 2]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    board.PlaceDisk(2, 1);
    Assert.AreEqual(SquareState.Black, board[2, 1]);
    Assert.AreEqual(SquareState.Black, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.Black, board[3, 1]);
    Assert.AreEqual(SquareState.Black, board[4, 1]);
    Assert.AreEqual(SquareState.Black, board[3, 2]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(Color.White, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[1, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 2]);
    Assert.AreEqual(SquareState.Black, board[4, 2]);
    Assert.AreEqual(SquareState.White, board[5, 2]);
    board.PlaceDisk(1, 2);
    Assert.AreEqual(SquareState.White, board[1, 2]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.White, board[3, 2]);
    Assert.AreEqual(SquareState.White, board[4, 2]);
    Assert.AreEqual(SquareState.White, board[5, 2]);
    Assert.AreEqual(Color.Black, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[1, 1]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    board.PlaceDisk(1, 1);
    Assert.AreEqual(SquareState.Black, board[1, 1]);
    Assert.AreEqual(SquareState.Black, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    Assert.AreEqual(Color.White, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[0, 0]);
    Assert.AreEqual(SquareState.Black, board[1, 1]);
    Assert.AreEqual(SquareState.Black, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 4]);
    Assert.AreEqual(SquareState.White, board[5, 5]);
    board.PlaceDisk(0, 0);
    Assert.AreEqual(SquareState.White, board[0, 0]);
    Assert.AreEqual(SquareState.White, board[1, 1]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(SquareState.White, board[5, 5]);
    Assert.AreEqual(Color.Black, board.Turn);

    Assert.AreEqual(SquareState.Empty, board[0, 1]);
    Assert.AreEqual(SquareState.White, board[1, 1]);
    Assert.AreEqual(SquareState.Black, board[2, 1]);
    Assert.AreEqual(SquareState.White, board[1, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    board.PlaceDisk(0, 1);
    Assert.AreEqual(SquareState.Black, board[0, 1]);
    Assert.AreEqual(SquareState.Black, board[1, 1]);
    Assert.AreEqual(SquareState.Black, board[2, 1]);
    Assert.AreEqual(SquareState.Black, board[1, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(Color.White, board.Turn);
    
    Assert.AreEqual(SquareState.Empty, board[2, 4]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 4]);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    board.PlaceDisk(2, 4);
    Assert.AreEqual(SquareState.White, board[2, 4]);
    Assert.AreEqual(SquareState.White, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.White, board[3, 4]);
    Assert.AreEqual(SquareState.White, board[4, 4]);
    Assert.AreEqual(Color.Black, board.Turn);
    
    Assert.AreEqual(SquareState.Empty, board[1, 3]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 1]);
    Assert.AreEqual(SquareState.White, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    board.PlaceDisk(1, 3);
    Assert.AreEqual(SquareState.Black, board[1, 3]);
    Assert.AreEqual(SquareState.Black, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[3, 1]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.Black, board[3, 3]);
    Assert.AreEqual(SquareState.Black, board[4, 3]);
    Assert.AreEqual(Color.White, board.Turn);
    
    Assert.AreEqual(SquareState.Empty, board[2, 0]);
    Assert.AreEqual(SquareState.Black, board[2, 1]);
    Assert.AreEqual(SquareState.Black, board[2, 2]);
    Assert.AreEqual(SquareState.Black, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[2, 4]);
    Assert.AreEqual(SquareState.Black, board[3, 1]);
    Assert.AreEqual(SquareState.White, board[4, 2]);
    board.PlaceDisk(2, 0);
    Assert.AreEqual(SquareState.White, board[2, 0]);
    Assert.AreEqual(SquareState.White, board[2, 1]);
    Assert.AreEqual(SquareState.White, board[2, 2]);
    Assert.AreEqual(SquareState.White, board[2, 3]);
    Assert.AreEqual(SquareState.White, board[2, 4]);
    Assert.AreEqual(SquareState.White, board[3, 1]);
    Assert.AreEqual(SquareState.White, board[4, 2]);
    Assert.AreEqual(Color.Black, board.Turn);
  }
}