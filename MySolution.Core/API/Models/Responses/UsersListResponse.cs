using Newtonsoft.Json;

namespace MySolution.Core.API.Models.Responses;

public class UsersListResponse
{
    [JsonProperty("data")]
    public List<User> Data { get; set; }
}