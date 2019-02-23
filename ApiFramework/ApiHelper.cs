using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ApiFramework
{
    public class ApiHelper
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        public IRestResponse Response { get; set; }
        public string ApiUrl { get; set; } = "https://reqres.in";

        public RestRequest RestRequest { get => _restRequest; set => _restRequest = value; }

        public string SetEndpoint(string endpoint)
        {
            ApiUrl = ApiUrl + endpoint;
            return ApiUrl; 
        }
        
        // This is the Request Class to make request

        public RestRequest MakeRequest()
        {
            RestRequest = new RestRequest(Method.GET);
            return RestRequest;
        }

        public IRestResponse GetResponse(RestRequest myRequest)
        {
            RestClient restClient = new RestClient(ApiUrl);
            IRestResponse respo = restClient.Execute(RestRequest);
            return respo;
        }

        public T DeserializeJsonObject<T>( IRestResponse response) where T : BaseClass, new()
        {
            
           return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
