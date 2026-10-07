using MySolution.Core.API.Models;
using RestSharp;

namespace MySolution.Core.API.Clients;

public class UsersClient : ApiClient
{
    private const string endpoint = "api/users/";
    
    public UsersClient(string baseUrl)
        : base(baseUrl)
    {
    }

    public RestResponse<UserResponse> GetUser(int id)
    {
        return Get<UserResponse>(endpoint + id);
    }
    
    
    public RestResponse<UserListResponse> GetUserPage(int pageNumber)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            {"page", pageNumber.ToString()}
        };
        return Get<UserListResponse>(endpoint, parameters);
    }
}