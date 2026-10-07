using System.Text.Json.Serialization;

namespace MySolution.Core.API.Models;

public class UserResponse
{
    [JsonPropertyName("data")]
    public User Data { get; set; }
}