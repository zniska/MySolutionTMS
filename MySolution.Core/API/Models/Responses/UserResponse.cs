using Newtonsoft.Json;

namespace MySolution.Core.API.Models.Responses;

public class UserResponse
{
    [JsonProperty("data")]
    public User Data { get; set; }
}