using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OthelloLib.Enums;

namespace OthelloWebApi.Dto;

public class StartGameResponse
{
  [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
  public SquareState[,] Board { get; init; } = new SquareState[0, 0];

  [JsonConverter(typeof(StringEnumConverter))]
  public Color Turn { get; init; } = Color.Black;

  public int BlackScore { get; init; }
  public int WhiteScore { get; init; }
}