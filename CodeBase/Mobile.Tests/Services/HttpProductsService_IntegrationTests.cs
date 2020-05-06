using Backend;
using Commons.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Mobile.Tests.Services
{
    public class HttpProductsService_IntegrationTests
    {
        private readonly HttpProductsService httpProductsService;
        private readonly ITestOutputHelper output;
        private readonly TestServer server;
        private readonly HttpClient client;

        public HttpProductsService_IntegrationTests(ITestOutputHelper output)
        {
            this.httpProductsService = new HttpProductsService();
            this.output = output;
            this.server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                 .UseConfiguration(new ConfigurationBuilder()

                 //.AddJsonFile("appsettings_server1.json")
                 .Build())
                 );
            this.client = server.CreateClient();
        }

        [Fact]
        public async void GetProduct_DoesNotThrowException()
        {
            //Arrange
            Product mockProduct = Product.GetMockProducts().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpProductsService.GetProduct(mockProduct.Barcode, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void GetProductsOfBasket_DoesNotThrowException()
        {
            //Arrange
            Basket mockBasket = Basket.GetMockBaskets().First();
           
            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpProductsService.GetProductsOfBasket(mockBasket.ID, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }
    }
}
