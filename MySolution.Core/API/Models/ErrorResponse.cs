using System.Text.Json.Serialization;

namespace MySolution.Core.API.Models;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; }
}