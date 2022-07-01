using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OthelloLib.Enums;

namespace OthelloWebApi.Dto;

public class NextTurnRequest
{
  [JsonProperty(ItemConverterType=typeof(StringEnumConverter))]
  public SquareState[,] Board { get; init; } = new SquareState[0, 0];
  
  [JsonConverter(typeof(StringEnumConverter))]
  public Color LastPlayedPlayer { get; set; } = Color.Black;
}