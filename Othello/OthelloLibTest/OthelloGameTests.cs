using OthelloLib;
using OthelloLib.Enums;
using OthelloLib.Exceptions;

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

  [TestMethod]
  // Test that placeDisk() ends the game correctly
  public void TestPlaceDiskGameOver()
  {
    char[,] charBoard =
    {
      {'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e'},
      {'e', 'e', 'e', 'e', 'b', 'w', 'e', 'e'},
      {'w', 'w', 'w', 'w', 'b', 'w', 'w', 'b'},
      {'e', 'e', 'w', 'w', 'b', 'w', 'e', 'b'},
      {'e', 'e', 'w', 'w', 'w', 'e', 'e', 'b'},
      {'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e'},
      {'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e'},
      {'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e'},
    };

    SquareState[,] board = ConvertBoard(charBoard);
    IOthelloGame game = OthelloGameBuilder.BuildGame(board, Color.White);
    Assert.IsFalse(game.IsGameOver());
    Assert.IsFalse(game.IsTie());
    Assert.IsFalse(game.HasWinner());
    Assert.AreEqual(Color.White, game.Turn);
    Assert.IsTrue(game.HasValidPlacement());
    Assert.IsTrue(game.IsValidPlacement(0, 4));
    Assert.AreEqual(SquareState.Empty, game[0, 4]);
    var gameNotOverException = Assert.ThrowsException<GameNotOverException>(() => game.Winner);
    Assert.AreEqual(gameNotOverException.Message, "Game is not over. There is no winner.");

    game.PlaceDisk(0, 4);

    Assert.IsTrue(game.IsGameOver());
    Assert.IsFalse(game.IsTie());
    Assert.IsTrue(game.HasWinner());
    Assert.IsFalse(game.HasValidPlacement());
    Assert.IsFalse(game.IsValidPlacement(0, 4));
    Assert.AreEqual(SquareState.White, game[0, 4]);
    Assert.AreEqual(Color.White, game.Winner);
    var gameOverException = Assert.ThrowsException<GameOverException>(() => game.Turn);
    Assert.AreEqual(gameOverException.Message, "The game is over.");
  }

  private static SquareState[,] ConvertBoard(char[,] board)
  {
    int height = board.GetLength(0);
    int width = board.GetLength(1);
    var convertedBoard = new SquareState[height, width];
    for (int row = 0; row < height; row += 1)
    {
      for (int col = 0; col < width; col += 1)
      {
        char cell = board[row, col];
        if (cell == 'b')
        {
          convertedBoard[row, col] = SquareState.Black;
        }
        else if (cell == 'w')
        {
          convertedBoard[row, col] = SquareState.White;
        }
        else if (cell == 'e')
        {
          convertedBoard[row, col] = SquareState.Empty;
        }
      }
    }

    return convertedBoard;
  }
}