using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OthelloLib.Enums;

namespace OthelloWebApi.Dto;

public class NextTurnResponse
{
  [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
  public SquareState[,] Board { get; init; } = new SquareState[0, 0];

  public int BlackScore { get; init; }
  public int WhiteScore { get; init; }
  public bool IsGameOver { get; init; }
  public bool IsTie { get; init; }

  [JsonConverter(typeof(StringEnumConverter))]
  public Color? Turn { get; init; }

  [JsonConverter(typeof(StringEnumConverter))]
  public Color? Winner { get; init; }
}