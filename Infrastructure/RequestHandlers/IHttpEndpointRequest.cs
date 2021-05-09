using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Services.Quotes.Dtos;

namespace Infrastructure.RequestHandlers
{
    public interface IHttpEndpointRequest
    {
        Task<T> Get<T>(string url) where T : class;
        Task<T> Post<T>(string url, string requestBody, string mediaType, OAuthKeyResponseModel oAuthKeyResponseModel=null) where T : class;
    }
}