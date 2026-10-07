using System.Text.Json.Serialization;

namespace MySolution.Core.API.Models;

public class UserListResponse
{
    [JsonPropertyName("data")]
    public List<User> Data { get; set; }
}