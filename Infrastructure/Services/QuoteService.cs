
using Core.Entities;
using System;
using System.Collections.Generic;
using Infrastructure.Services.Quotes.Dtos;
using Infrastructure.RequestHandlers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Infrastructure.TenantProvider;
using Infrastructure.Repositories;
using System.Linq;

namespace Infrastructure.Services.Quotes
{
  public class QuoteService : IQuoteService
  {
    private IHttpEndpointRequest _httpEndpointRequest;
    private ITenantProvider _tenantProvider;
    private readonly IGenericRepository<Service> _serviceRepository;
    private Tenant _tenant;
    private string _authCredentials;

    public QuoteService(IHttpEndpointRequest httpEndpointRequest, ITenantProvider tenantProvider, IGenericRepository<Service> serviceRepository)
    {
      _tenantProvider = tenantProvider;
      _serviceRepository = serviceRepository;
      _tenant = _tenantProvider.GetTenant();
      _httpEndpointRequest = httpEndpointRequest;
      _authCredentials = $"grant_type=client_credentials&scope={this._tenant.Scope}&client_id={this._tenant.ClientId}&client_secret={this._tenant.ClientSecret}";
    }


    public async Task<List<Quote>> GetQuotes(decimal? weight)
    {

      var authRequestResponse = await this._httpEndpointRequest
           .Post<OAuthKeyResponseModel>(QuoteRequestParameters.AuthenticationEnpoint
                                       , _authCredentials
                                       , "application/x-www-form-urlencoded");


      if (authRequestResponse.AccessToken == null)
      {
        throw new Exception("Unable to authenticate request, no auth key response was returned from the authentication host: " + QuoteRequestParameters.AuthenticationEnpoint);

      }

      var quoteRequest = new QuoteRequest(weight);
      var requestBody = JsonConvert.SerializeObject(quoteRequest);

      var quotesRequestResponse = await this._httpEndpointRequest
            .Post<Quote>(QuoteRequestParameters.ApiEndpoint, requestBody, "application/json", authRequestResponse);

      //await PopulateServices(quotesRequestResponse.Quotes);

      return quotesRequestResponse.Quotes;

    }

    
    private async Task PopulateServices(List<Quote> quotes)
    {
      var services = await _serviceRepository.ListAllAsync();
      foreach (var quote in quotes)
      {
        if(!services.Any(x=>x.Name==quote.Service.Name)){
          var service = quote.Service;
          service.Imagelarge = quote.Service.Links.Imagelarge;
          service.ImageSmall = quote.Service.Links.ImageSmall;
          service.ImageSvg = quote.Service.Links.ImageSvg;
          service.Links=null;
          _serviceRepository.Add(service);
          await _serviceRepository.Save();
        }
      }
    }

  }
}
