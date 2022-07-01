using Microsoft.AspNetCore.Mvc;
using OthelloLib;
using OthelloLib.Enums;
using OthelloWebApi.Dto;

namespace OthelloWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OthelloController : ControllerBase
{
  private readonly IComputerPlayer _computerPlayer;

  public OthelloController(IComputerPlayer computerPlayer)
  {
    _computerPlayer = computerPlayer;
  }

  [HttpGet("start")]
  [ProducesResponseType(200, Type = typeof(StartGameResponse))]
  public StartGameResponse StartGame()
  {
    IOthelloGame game = OthelloGameBuilder.BuildGame();
    var response = new StartGameResponse
      {Board = game.Board, Turn = game.Turn, BlackScore = game.BlackScore, WhiteScore = game.WhiteScore};
    return response;
  }

  [HttpPost("next")]
  [ProducesResponseType(200, Type = typeof(NextTurnResponse))]
  public IActionResult NextRound([FromBody] NextTurnRequest request)
  {
    SquareState[,] board = request.Board;
    Color lastPlayedPlayer = request.LastPlayedPlayer;
    IOthelloGame game = OthelloGameBuilder.BuildGame(board, lastPlayedPlayer);
    if (game.IsGameOver())
    {
      return BadRequest("Supplied game is over. No next round.");
    }
    
    _computerPlayer.PlaceUntilTurnChanges(game);
    bool isGameOver = game.IsGameOver();
    bool isTie = game.IsTie();

    var response = new NextTurnResponse
    {
      Board = game.Board,
      BlackScore = game.BlackScore,
      WhiteScore = game.WhiteScore,
      IsGameOver = isGameOver,
      IsTie = isTie,
      Turn = isGameOver ? null : game.Turn,
      Winner = isGameOver && !isTie ? game.Winner : null,
    };

    return Ok(response);
  }
}