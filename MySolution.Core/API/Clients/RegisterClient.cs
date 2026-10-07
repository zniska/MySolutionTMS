using MySolution.Core.API.Models.Requests;
using MySolution.Core.API.Models.Responses;
using Newtonsoft.Json;

namespace MySolution.Core.API.Clients;

public class RegisterClient : ApiClient
{
    private readonly string RegisterEndpoint = "/api/register";
    
    public RegisterClient(string endpoint) : base(endpoint)
    {
    }

    public T PostRegister<T>(RegisterRequest request)
    {
        var restResponse = Post(RegisterEndpoint, request);
        return JsonConvert.DeserializeObject<T>(restResponse.Content);
    }
}