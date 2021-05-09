
using Moq;
using NUnit.Framework;
using Infrastructure.RequestHandlers;
using Infrastructure.TenantProvider;
using Infrastructure.Repositories;
using Infrastructure.Services.Quotes;
using Core.Entities;
using Infrastructure.Services.Quotes.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Tests.Parcel2Go_NUnit_UnitTests.Infrastructure.Services
{
    [TestFixture]
    public class QuoteService_tests
    {
        private Mock<IHttpEndpointRequest> _httpEndpointRequest;
        private Mock<ITenantProvider> _tenantProvider;
        private Mock<IGenericRepository<Service>> _serviceRepository;



        [Test]
        public void SetUp(){
            

            var oAuthKeyResponseModel = new OAuthKeyResponseModel();
            oAuthKeyResponseModel=null;
            
            var quote = new Quote();
           
            _tenantProvider = new Mock<ITenantProvider>();
            _tenantProvider.Setup(x => x.GetTenant()).Returns(new Tenant{
               ClientId="",
               ClientSecret="",
               Host="",
               Name="",
               Scope=""
            });

            _httpEndpointRequest = new Mock<IHttpEndpointRequest>();
            _httpEndpointRequest.Setup(x=>x.Post<Quote>("", "", "", oAuthKeyResponseModel)).Returns(Task.FromResult(quote));
         

            _serviceRepository = new Mock<IGenericRepository<Service>>();
            

        }

        [Test]
        public void GetQuotes_UserNotAuthorised_ThrowsEception(){
            //Arrange

            var quoteService = new QuoteService(_httpEndpointRequest.Object,_tenantProvider.Object, _serviceRepository.Object );

            //Act
            var result = quoteService.GetQuotes(10);

            //Assert
            Assert.That(result, Is.EqualTo(new Exception("Unable to authenticate request, no auth key response was returned from the authentication host: ")));
        }

        [Test]
        public void GetQuotes_UserAutorised_ReturnsListOfQuotes(){
            //Arrange
            //Act
            //Assert
        }
        
    }
}