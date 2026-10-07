using System.Text.Json.Serialization;

namespace MySolution.Core.API.Models;

public class RegisterResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("token")]
    public string Token { get; set; }
}