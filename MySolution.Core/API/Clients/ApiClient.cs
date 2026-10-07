using RestSharp;

namespace MySolution.Core.API.Clients;

public class ApiClient
{
    protected readonly RestClient Client;

    public ApiClient(string baseUrl)
    {
        Client = new RestClient(baseUrl);
    }
    
    public RestResponse<T> Get<T>(string endpoint, Dictionary<string, string> queryParams = null)
    {
        
        var request = new RestRequest(endpoint);
        if (queryParams != null)
        {
            foreach (var param in queryParams)
            {
                request.AddQueryParameter(param.Key, param.Value);
            }
        }

        return Client.Execute<T>(request);
    }

    public RestResponse<T> Post<T>(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(body);

        return Client.Execute<T>(request);
    }
    
    public RestResponse Post(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(body);

        return Client.Execute(request);
    }
}