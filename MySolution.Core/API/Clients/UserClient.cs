using MySolution.Core.API.Models.Responses;
using Newtonsoft.Json;

namespace MySolution.Core.API.Clients;

public class UserClient : ApiClient
{
    private const string usersEndpoint = "api/users/";
    
    public UserClient(string baseUrl) : base(baseUrl)
    {
        
    }

    public UsersListResponse GetUsers()
    {
        var response = Get(usersEndpoint);
        return JsonConvert.DeserializeObject<UsersListResponse>(response.Content);
    }

    public UserResponse GetUser(int userId)
    {
        var response = Get(usersEndpoint + userId);
        return JsonConvert.DeserializeObject<UserResponse>(response.Content);
    }

    public UsersListResponse GetUsersByPage(int page)
    {
        Dictionary<string, string> queryParams = new Dictionary<string, string>()
        {
            { "page", page.ToString() }
        };
        
        var response = Get(usersEndpoint, queryParams);
        return JsonConvert.DeserializeObject<UsersListResponse>(response.Content);
    }
}