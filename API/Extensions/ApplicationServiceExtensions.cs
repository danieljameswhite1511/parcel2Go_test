using System.Linq;
using System.Net.Http;
using API.Errors;
using API.Helpers;
using Infrastructure.Repositories;
using Infrastructure.RequestHandlers;
using Infrastructure.Services.Quotes;
using Infrastructure.TenantProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
  public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){

            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<ITenantProvider, TenantProvider>();
            services.AddHttpClient<IHttpEndpointRequest, HttpEndpointRequest>()
                  .ConfigurePrimaryHttpMessageHandler(() =>
                    {
                        return new HttpClientHandler()
                        {
                            ClientCertificateOptions = ClientCertificateOption.Manual,
                            ServerCertificateCustomValidationCallback= 
                            (HttpRequestMessage, ClientCertificateOption, cetChain, policyErrors) =>
                            {
                                return true;
                            }
                        };
                    });
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepsository<>)));

            services.Configure<ApiBehaviorOptions>(options => {
                
                options.InvalidModelStateResponseFactory = actionContext => {

                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse{
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };

            });

            return services;

        }
    }
}