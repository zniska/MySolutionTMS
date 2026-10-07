using RestSharp;

namespace MySolution.Core.API.Clients;

public class ApiClient
{
    protected readonly RestClient Client;
    
    public ApiClient(string baseUrl)
    {
        Client = new RestClient(baseUrl);
    }

    public RestResponse Get(string endpoint, Dictionary<string, string> queryParams = null)
    {
        var request = new RestRequest(endpoint);
        
        request.AddHeader("Content-Type", "application/json");
        if (queryParams != null)
        {
            foreach (var parameter in queryParams)
            {
                request.AddQueryParameter(parameter.Key, parameter.Value);
            }
        }
        
        return Client.Execute(request);
    }

    public RestResponse Post(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);

        request.AddBody(body);
        return Client.Execute(request);
    }
}