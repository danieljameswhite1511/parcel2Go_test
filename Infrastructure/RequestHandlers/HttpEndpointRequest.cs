using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastructure.Services.Quotes.Dtos;

namespace Infrastructure.RequestHandlers
{
    public class HttpEndpointRequest :IHttpEndpointRequest
    {
    private readonly HttpClient _httpClient;

    public HttpEndpointRequest(HttpClient httpClient)
        {
      this._httpClient = httpClient;
    }
        public async Task<T> Get<T>(string url) where T : class
        {
            var request = await _httpClient.GetAsync(url);
            var response = request.Content.ReadAsAsync<T>().Result;

            return response;
        }
        

        public async Task<List<T>> GetList<T>(string url) where T : class
        {

            var request = await _httpClient.GetAsync(url);
            var response = request.Content.ReadAsAsync<List<T>>().Result;

            return response;

        }

        public async Task<T> Post<T>(string url, string requestBody, string mediaType, OAuthKeyResponseModel authKeyResponseModel=null) where T : class
        {
            var body = new StringContent(requestBody, Encoding.UTF8, mediaType);

             if(authKeyResponseModel!=null)
             {
                _httpClient.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue("Bearer", authKeyResponseModel.AccessToken);
             }

            var request = await _httpClient.PostAsync(url, body);
            var response = request.Content.ReadAsAsync<T>().Result;

            return response;
            
        }

        
    }
}