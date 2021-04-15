using Newtonsoft.Json;
using QuoteRetriever.Functions.GetQuotes.Models;
using QuoteRetriever.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace QuoteRetriever.Functions.GetQuotes
{
    public class QuoteRetriever : IQuoteRetriever
    {
        private string _content = "";
        private string _baseurl;
        private string _quoteendpoint;

        public QuoteRetriever(string scope, string clientId, string clientSecret, string baseUrl, string quoteendpoint)
        {
            _baseurl = baseUrl;
            _content = string.Format("grant_type=client_credentials&scope={0}&client_id={1}&client_secret={2}", scope, clientId, clientSecret);
            _quoteendpoint = quoteendpoint;
        }

        public List<Quote> GetQuotes(int weight)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _baseurl);
            request.Content = new StringContent(_content, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = client.SendAsync(request).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var key = new OAuthKeyResponseModel();
            if (response.IsSuccessStatusCode)
            {
                key = JsonConvert.DeserializeObject<OAuthKeyResponseModel>(responseContent);
            }
            else
            {
                throw new Exception("CANT AUTH");
            }

            var quoteRequest = new QuoteRequest(weight);
            var content = JsonConvert.SerializeObject(quoteRequest);

            var webRequest = new HttpRequestMessage(HttpMethod.Post, _quoteendpoint);
            webRequest.Content = new StringContent(content, Encoding.UTF8, "application/json");

            var httpCLient = new HttpClient();
            httpCLient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", key.AccessToken);

            var getREsponse = httpCLient.SendAsync(webRequest).Result;
            var quoteResponse = getREsponse.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Result>(quoteResponse).Quotes;
            }

            throw new Exception($"Error Calling Quotes: {responseContent}");

        }
    }
}
