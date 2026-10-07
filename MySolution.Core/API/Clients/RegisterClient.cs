using System.Text.Json;
using MySolution.Core.API.Models;
using OpenQA.Selenium.DevTools.V148.Runtime;
using RestSharp;

namespace MySolution.Core.API.Clients;

public class RegisterClient : ApiClient
{
    private const string endpoint = "api/register";
    
    public RegisterClient(string baseUrl)
        : base(baseUrl)
    {
    }
    
    
    public ApiResponse<RegisterResponse, ErrorResponse> PostRegister(RegisterRequest request)
    {
        var response = Post(endpoint, request);
        
        var result = new ApiResponse<RegisterResponse, ErrorResponse>
        {
            Response = response
        };

        if (response.IsSuccessful)
        {
            result.Success =
                JsonSerializer.Deserialize<RegisterResponse>(
                    response.Content);
        }
        else
        {
            result.Error =
                JsonSerializer.Deserialize<ErrorResponse>(
                    response.Content);
        }

        return result;
    }
}