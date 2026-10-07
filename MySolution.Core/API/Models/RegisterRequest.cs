using System.Text.Json.Serialization;

namespace MySolution.Core.API.Models;

public class RegisterRequest
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
}