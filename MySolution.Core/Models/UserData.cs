using System.Text.Json.Serialization;

namespace MySolution.Core.Models;

public class UserData
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
}