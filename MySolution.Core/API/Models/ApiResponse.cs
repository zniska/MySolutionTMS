using RestSharp;

namespace MySolution.Core.API.Models;

public class ApiResponse<TSuccess, TError>
    {
        public RestResponse Response { get; set; }

        public TSuccess Success { get; set; }

        public TError Error { get; set; }

        public bool IsSuccess =>
            Response.IsSuccessful;
}